using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class WalletTransactionMappingProfile : Profile
    {
        public WalletTransactionMappingProfile()
        {
            CreateMap<WalletTransaction, WalletTransactionViewModel>()
                .ForMember(
                    dest => dest.Time,
                    opt => opt.MapFrom(
                        src => src.UpdatedAt.ToFormatString()))
                .ForMember(
                    dest => dest.BookingCode,
                    opt => opt.MapFrom(
                        src => src.Booking.Code));

            CreateMap<WalletTransaction, WalletTransactionDTO>().ReverseMap();

            CreateMap<WalletTopUpRequest, WalletTransactionDTO>()
                .ForMember(
                    dest => dest.Type,
                    otp => otp.MapFrom(
                        src => GetWalletTopUpTransactionType(src.Type)));

            CreateMap<WalletTransaction, IncomeViewModel>()
                .ForMember(
                    dest => dest.TransactionCode,
                    otp => otp.MapFrom(src => src.BookingDetailCode)
                )
                .ForMember(
                    dest => dest.Date,
                    otp => otp.MapFrom(src => DateOnly.FromDateTime(src.CreatedAt.Date.Date))
                )
                .ForMember(
                    dest => dest.Time,
                    otp => otp.MapFrom(src => TimeOnly.FromTimeSpan(src.CreatedAt.TimeOfDay))
                ).ForMember(
                    dest => dest.TransactionCode,
                    otp => otp.MapFrom(src => src.Code)
                ).ForMember(
                    dest => dest.StartStation,
                    otp => otp.MapFrom(src => src.Booking.StartRouteStation.Station)
                ).ForMember(
                    dest => dest.EndStation,
                    otp => otp.MapFrom(src => src.Booking.EndRouteStation.Station)
                );
        }

        private WalletTransactions.Types GetWalletTopUpTransactionType(AffiliateParties.PartyTypes type)
        {
            switch (type)
            {
                case AffiliateParties.PartyTypes.Momo:
                    return WalletTransactions.Types.MomoIncome;
                case AffiliateParties.PartyTypes.VNPay:
                    return WalletTransactions.Types.VnPayIncome;
                default: return WalletTransactions.Types.ZaloPayIncome;
            }
        }
    }
}
