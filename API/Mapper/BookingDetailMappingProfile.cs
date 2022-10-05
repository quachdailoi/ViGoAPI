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
            CreateMap<BookingDetail, BookingDetailViewModel>();

            CreateMap<BookingDetail, BookerBookingDetailViewModel>()
                .ForMember(
                    dest => dest.Driver,
                    otp => otp.MapFrom(
                        src => src.BookingDetailDrivers
                        .Where(bdr => bdr.Status == BookingDetailDrivers.Status.Pending)
                        .First().Driver))
                .IncludeBase<BookingDetail, BookingDetailViewModel>();

            CreateMap<BookingDetail, DriverBookingDetailViewModel>()
                .ForMember(
                    dest => dest.User,
                    otp => otp.MapFrom(
                        src => src.Booking.User))
                .IncludeBase<BookingDetail, BookingDetailViewModel>();
        }
    }
}
