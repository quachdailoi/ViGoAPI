using API.Models;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class BookingDetailMappingProfile : Profile
    {
        public BookingDetailMappingProfile()
        {
            CreateMap<BookingDetail, BookingDetailViewModel>();

            CreateMap<BookingDetail, BookerBookingDetailViewModel>()
                .IncludeBase<BookingDetail, BookingDetailViewModel>();

            CreateMap<BookingDetail, DriverBookingDetailViewModel>()
                .IncludeBase<BookingDetail, BookingDetailViewModel>();
        }
    }
}
