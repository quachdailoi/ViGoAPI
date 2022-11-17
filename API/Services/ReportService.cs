﻿using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using API.TaskQueues.TaskResolver;
using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ReportService : BaseService, IReportService
    {
        public ReportService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<Response> Create(ReportDTO reportDto, Response successResponse, Response failResponse)
        {
            var report = Mapper.Map<Report>(reportDto);

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

        public async Task<Response> Get(PagingRequest request, Response response, Reports.Status? status = null)
        {
            var reports = UnitOfWork.Reports.List();

            if (status.HasValue)
                reports = reports.Where(e => e.Status == status.Value);

            var paging = reports.PagingMap<Report, ReportViewModel>(Mapper, page: request.Page, pageSize: request.PageSize, AppServices);

            return response.SetData(paging);
        }

        public async Task<Response> GetData(Guid code, Response successResponse, Response notFoundResponse)
        {
            var report =
                await UnitOfWork.Reports.List(e => e.Code == code)
                .FirstOrDefaultAsync();

            if (report == null)
                return notFoundResponse;

            dynamic? data;

            switch (report.Type)
            {
                case Reports.Types.DriverNotComming:
                    var bookingDetailCode = report.GetData<Guid?>();

                    if (bookingDetailCode == null)
                        return notFoundResponse;

                    data = await AppServices.BookingDetail.GetBookerViewModelByCode(bookingDetailCode.Value);
                    break;
                default:
                    return notFoundResponse;

            }

            return successResponse.SetData(data);
        }

        public async Task<bool?> UpdateStatus(Guid code, Reports.Status status)
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
                            var bookingDetailCode = report.GetData<Guid?>();
                            if (bookingDetailCode != null)
                            {
                                var bookingDetail = await AppServices.Booking.MappingBookingDetailSuddenly(bookingDetailCode.Value);

                                if(bookingDetail != null)
                                {
                                    var bookingDetailDriver = bookingDetail.BookingDetailDrivers.Where(bdr => bdr.TripStatus == BookingDetailDrivers.TripStatus.NotYet).FirstOrDefault();
                                    if (bookingDetailDriver != null && UnitOfWork.BookingDetails.Update(bookingDetail).Result)
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
                                    else if(bookingDetailDriver == null)
                                    {
                                        await AppServices.RedisMQ.Publish(RefundBookingTask.REFUND_QUEUE, new RefundItemDTO
                                        {
                                            Amount = bookingDetail.Price,
                                            Code = bookingDetail.Code,
                                            Type = TaskItems.RefundItemTypes.BookingDetail
                                        });
                                    }
                                }
                            }
                            break;
                    }
                    break;
                default:
                    break;
            }

            return await UnitOfWork.Reports.Update(report);
        }
    }
}