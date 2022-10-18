﻿using API.Extensions;
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
                        src => src.MessageRoom.Code))
                .ForMember(
                    dest => dest.StatusName,
                    opt => opt.MapFrom(
                        src => src.Status.DisplayName()));

            CreateMap<BookingDetail, BookerBookingDetailViewModel>()
                .ForMember(
                    dest => dest.Driver,
                    opt => opt.MapFrom(
                        src => src.BookingDetailDrivers
                        .Where(bdr => bdr.Status == BookingDetailDrivers.Status.Pending)
                        .FirstOrDefault().Driver))
                .ForMember(
                    dest => dest.Time,
                    opt => opt.MapFrom(
                        src => src.Booking.Time))
                .ForMember(
                    dest => dest.BookingCode,
                    opt => opt.MapFrom(
                        src => src.Booking.Code))
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
