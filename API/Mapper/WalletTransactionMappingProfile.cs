﻿using API.Extensions;
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
                    dest => dest.DateTime,
                    otp => otp.MapFrom(src => src.CreatedAt)
                ).ForMember(
                    dest => dest.TransactionCode,
                    otp => otp.MapFrom(src => src.Code)
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
