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
            IAppServices? service = null;

            CreateMap<Booking, BookingViewModel>()
                .ForMember(
                    dest => dest.StatusName,
                    otp => otp.MapFrom(
                            src => src.Status.DisplayName()))
                .ForMember(
                    dest => dest.Stations,
                    otp => otp.MapFrom(
                    src => src.StartRouteStation.Route.RouteStations
                        .OrderBy(x => x.DistanceFromFirstStationInRoute)
                        .Select(routeStation => routeStation.Station)));

            CreateMap<Booking, BookerBookingViewModel>()
                .ForMember(
                    dest => dest.CreatedAt,
                    otp => otp.MapFrom(
                            src => src.CreatedAt.ToFormatString()))
                .ForMember(
                    dest => dest.TypeName,
                    opt => opt.MapFrom(
                            src => src.Type.DisplayName()))
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

    public static class BookingMappingSupport
    {
        public static List<Station> GetOrderedStations(this IAppServices? appServices, RouteStation start, RouteStation end)
        {
            return appServices.RouteStation.GetOrderedStationsInRoute(start, end);
        }
    }
}