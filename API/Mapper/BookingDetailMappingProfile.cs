using API.Extensions;
using API.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class BookingDetailMappingProfile : Profile
    {
        public BookingDetailMappingProfile()
        {
            CreateMap<BookingDetail, BookingDetailViewModel>()
                .ForMember(
                    dest => dest.ChattingRoomCode,
                    opt => opt.MapFrom(
                        src => src.MessageRoom.Code));

            CreateMap<BookingDetail, BookerBookingDetailViewModel>()
                .ForMember(
                    dest => dest.Driver,
                    opt => opt.MapFrom(
                        src => src.BookingDetailDrivers
                        .Where(bdr => bdr.TripStatus != BookingDetailDrivers.TripStatus.Cancelled)
                        .FirstOrDefault().Driver))
                .ForMember(
                    dest => dest.DriverStatus,
                    opt => opt.MapFrom(
                        src => src.BookingDetailDrivers
                        .Where(bdr => bdr.TripStatus != BookingDetailDrivers.TripStatus.Cancelled)
                        .FirstOrDefault().TripStatus))
                .ForMember(
                    dest => dest.Time,
                    opt => opt.MapFrom(
                        src => src.Booking.Time))
                .ForMember(
                    dest => dest.BookingCode,
                    opt => opt.MapFrom(
                        src => src.Booking.Code))
                .ForMember(
                    dest => dest.StartStation,
                    opt => opt.MapFrom(
                        src => src.Booking.StartRouteStation.Station))
                .ForMember(
                    dest => dest.EndStation,
                    opt => opt.MapFrom(
                        src => src.Booking.EndRouteStation.Station))
                .ForMember(
                    dest => dest.BookingType,
                    opt => opt.MapFrom(
                        src => src.Booking.VehicleType.Type.DisplayName()))
                .IncludeBase<BookingDetail, BookingDetailViewModel>();

            CreateMap<BookingDetail, DriverBookingDetailViewModel>()
                .ForMember(
                    dest => dest.User,
                    otp => otp.MapFrom(
                        src => src.Booking.User))
                .IncludeBase<BookingDetail, BookingDetailViewModel>();

            CreateMap<BookingDetail, IncomeViewModel>()
                .ForMember(
                    dest => dest.BookingDetailCode,
                    opt => opt.MapFrom(
                        src => src.Code
                    )
                ).
                ForMember(
                    dest => dest.DateTime,
                    opt => opt.MapFrom(
                        src => src.Date.ToDateTime((TimeOnly)src.BookingDetailDrivers.Where(x => x.TripStatus == BookingDetailDrivers.TripStatus.Completed).FirstOrDefault().EndTime)
                    )
                );
        }
    }
}
