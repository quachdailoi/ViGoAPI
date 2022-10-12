using API.Controllers.V1;
using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {

            CreateMap<Booking, BookingViewModel>();

            CreateMap<Booking, BookerBookingViewModel>()
                .ForMember(
                    dest => dest.Stations,
                    otp => otp.MapFrom(
                            src => src.Route.RouteStations
                                .Select(routeStation =>
                                    routeStation.Station)))
                .AfterMap((src, dest) =>
                {
                    dest.Distance = 0;
                    var startIndex = dest.Stations.Where(station => station.Code == src.StartStationCode).First().Index;
                    var endIndex = dest.Stations.Where(station => station.Code == src.EndStationCode).First().Index;

                    dest.Stations = dest.Stations.OrderBy(station => station.Index).ToList();

                    var stationAfterStart = dest.Stations.Where(station => station.Index >= startIndex).ToList();
                    var stationBeforeEnd = dest.Stations.Where(station => station.Index <= endIndex).ToList();

                    dest.Stations = startIndex <= endIndex ?
                        stationAfterStart.Intersect(stationBeforeEnd).ToList() : stationAfterStart.Concat(stationBeforeEnd).ToList();
                })
                .IncludeBase<Booking, BookingViewModel>();

            CreateMap<Booking, DriverBookingViewModel>()
                .IncludeBase<Booking, BookingViewModel>();

            CreateMap<BookingDTO, Booking>()
                .ReverseMap();

            CreateMap<CreateBookingRequest, BookingDTO>()
                .ForMember(
                    dest => dest.Time,
                    otp => otp.MapFrom(
                            src => new TimeOnly().ParseExact(src.Time)))
                .ForMember(
                    dest => dest.StartAt,
                    otp => otp.MapFrom(
                            src => new DateOnly().ParseExact(src.StartAt)))
                .ForMember(
                    dest => dest.EndAt,
                    otp => otp.MapFrom(
                            src => new DateOnly().ParseExact(src.EndAt)))
                .ForMember(
                    dest => dest.Option,
                    otp => otp.MapFrom(
                        src => (new DateOnly().ParseExact(src.EndAt).Day == 1) ? 
                        Bookings.Options.StartAtFollowingTime : Bookings.Options.StartAtNextDay));

            CreateMap<GetProvisionalBookingRequest, BookingDTO>()
                .ForMember(
                    dest => dest.Time,
                    otp => otp.MapFrom(
                            src => new TimeOnly().ParseExact(src.Time)))
                .ForMember(
                    dest => dest.StartAt,
                    otp => otp.MapFrom(
                            src => new DateOnly().ParseExact(src.StartAt)))
                .ForMember(
                    dest => dest.EndAt,
                    otp => otp.MapFrom(
                            src => new DateOnly().ParseExact(src.EndAt)));
        }
    }
}
