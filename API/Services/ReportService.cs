﻿using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using API.TaskQueues.TaskResolver;
using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace API.Services
{
    public class ReportService : BaseService, IReportService
    {
        public ReportService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<Response> Create(ReportDTO reportDto, Response successResponse, Response duplicateResponse,Response failResponse)
        {
            var report = Mapper.Map<Report>(reportDto);

            switch (reportDto.Type)
            {
                case Reports.Types.DriverNotComming:
                    var duplicateReport = await UnitOfWork.Reports.List(x => x.Data == $"\"{reportDto.Data}\"").FirstOrDefaultAsync();

                    if(duplicateReport != null)
                        switch (duplicateReport.Status)
                        {
                            case Reports.Status.Pending:
                                return duplicateResponse.SetMessage("This report has been received and in processcing.");
                            case Reports.Status.Processced:
                                return duplicateResponse.SetMessage("This report has been processed");
                            default:
                                return duplicateResponse.SetMessage("This report has been ignored to process");

                        };
                    break;
            }

            report = await UnitOfWork.Reports.Add(report);

            if (report == null)
                return failResponse;

            await AppServices.Notification.SendPushNotification(new NotificationDTO
            {
                Type = Notifications.Types.Admin,
                EventId = Events.Types.NewReport
            });

            return successResponse;
        }

        public Response Get(PagingRequest? paging, Response response, string searchValue)
        {
            searchValue = searchValue.Trim().ToLower();

            object? data;

            var reports = UnitOfWork.Reports
                    .List(
                        e => e.User.Accounts.Any(a => a.RegistrationType == RegistrationTypes.Phone && a.Registration.Contains(searchValue)) ||
                        e.User.Name.Trim().ToLower().Contains(searchValue)
                    );

            if (paging != null) data = reports.PagingMap<Report, ReportViewModel>(Mapper, page: paging.Page, pageSize: paging.PageSize, AppServices);
            else data = reports.MapTo<ReportViewModel>(Mapper, AppServices);

            return response.SetData(data);
        }

        public async Task<Response> GetData(Guid code, Response successResponse, Response notFoundResponse)
        {
            var report =
                await UnitOfWork.Reports.List(e => e.Code == code)
                .MapTo<ReportViewModel>(Mapper,AppServices)
                .FirstOrDefaultAsync();

            if (report == null)
                return notFoundResponse;

            dynamic data = new ExpandoObject();

            data = report;

            switch (report.Type)
            {
                case Reports.Types.DriverNotComming:
                    var bookingDetailCode = report.GetData<Guid>();

                    //if (bookingDetailCode == null)
                    //    return notFoundResponse;

                    data.Data = await AppServices.BookingDetail.GetBookerViewModelByCode(bookingDetailCode);
                    break;
                default:
                    return notFoundResponse;

            }

            return successResponse.SetData(data);
        }

        public async Task<bool?> UpdateStatus(int userId, Guid code, Reports.Status status)
        {
            var report =
                await UnitOfWork.Reports.List(e => e.Code == code)
                .FirstOrDefaultAsync();

            if (report == null)
                return null;

            report.Status = status;

            switch (status)
            {
                case Reports.Status.Processced:
                    switch (report.Type)
                    {
                        case Reports.Types.DriverNotComming:
                            var bookingDetailCode = report.GetData<Guid>();
                            var bookingDetail = await AppServices.Booking.MappingBookingDetailSuddenly(bookingDetailCode);

                            if (bookingDetail != null && UnitOfWork.BookingDetails.Update(bookingDetail).Result)
                            {
                                var bookingDetailDriver = bookingDetail.BookingDetailDrivers.Where(bdr => bdr.TripStatus == BookingDetailDrivers.TripStatus.NotYet).FirstOrDefault();
                                if (bookingDetailDriver != null)
                                {
                                    var driver = await UnitOfWork.RouteRoutines.List(e => e.Id == bookingDetailDriver.RouteRoutineId).Select(e => e.User).FirstOrDefaultAsync();

                                    var notiDTO = new NotificationDTO()
                                    {
                                        EventId = Events.Types.HaveTripSuddenly,
                                        Type = Notifications.Types.SpecificUser,
                                        Token = driver?.FCMToken,
                                        UserId = driver?.Id
                                    };

                                    await AppServices.Notification.SendPushNotification(notiDTO);
                                }
                                else
                                {
                                    await AppServices.RedisMQ.Publish(RefundBookingTask.REFUND_QUEUE, new RefundItemDTO
                                    {
                                        Amount = bookingDetail.Price,
                                        Code = bookingDetail.Code,
                                        Type = TaskItems.RefundItemTypes.BookingDetail
                                    });
                                }

                                var reportedDriver = bookingDetail.BookingDetailDrivers.Where(bdr => bdr.TripStatus == BookingDetailDrivers.TripStatus.Cancelled).OrderBy(e => e.CreatedAt).LastOrDefault()?.RouteRoutine.User;

                                if(reportedDriver != null)
                                {
                                    await AppServices.User.UpdateStatus(reportedDriver.Id, Users.Status.Inactive);

                                    var notiDTO = new NotificationDTO()
                                    {
                                        EventId = Events.Types.BanDriver,
                                        Type = Notifications.Types.SpecificUser,
                                        Token = reportedDriver.FCMToken,
                                        UserId = reportedDriver.Id
                                    };

                                    await AppServices.Notification.SendPushNotification(notiDTO);

                                    var bookingDetailIds = await AppServices.BookingDetailDriver.GetNotYetBookingDetailId(reportedDriver.Id);

                                    await AppServices.BookingDetail.Cancel(bookingDetailIds);

                                    foreach(var id in bookingDetailIds)
                                    {
                                        await AppServices.RedisMQ.Publish(MappingBookingTask.MAPPING_QUEUE, new MappingItemDTO
                                        {
                                            Id = id,
                                            Type = TaskItems.MappingItemTypes.BookingDetail
                                        });
                                    }
                                }
                            }

                            break;
                    }
                    report.UpdatedBy = userId;
                    break;
                default:
                    break;
            }

            return await UnitOfWork.Reports.Update(report);
        }
    }
}
