using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<Booking, BookingViewModel>();

            CreateMap<Booking, BookerBookingViewModel>()
                .IncludeBase<Booking, BookingViewModel>();

            CreateMap<Booking, DriverBookingViewModel>()
                .IncludeBase<Booking, BookingViewModel>();

            CreateMap<Booking, BookingDTO>()
                //.ForMember(
                //    dest => dest.EndTime,
                //    otp => otp.MapFrom(
                //        src => src.Time.AddMinutes(src.Duration/60)
                //        )
                //)
                .ReverseMap();

            CreateMap<CreateBookingRequestModel, BookingDTO>();
        }
    }
}
