using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Mapper
{
    public class WalletMappingProfile : Profile
    {
        public WalletMappingProfile()
        {
            CreateMap<WalletTransaction, WalletTransactionDTO>().ReverseMap();

            CreateMap<WalletTopUpRequest, WalletTransactionDTO>()
                .ForMember(
                    dest => dest.Type,
                    otp => otp.MapFrom(
                        src => GetWalletTopUpTransactionType(src.AffiliatePartyType)));

            CreateMap<Wallet, WalletViewModel>();
        }

        public WalletTransactions.Types GetWalletTopUpTransactionType(AffiliatePartyTypes.Types type)
        {
            switch (type)
            {
                case AffiliatePartyTypes.Types.Momo:
                    return WalletTransactions.Types.MomoIncome;
                case AffiliatePartyTypes.Types.VNPay:
                    return WalletTransactions.Types.VnPayIncome;
                default: return WalletTransactions.Types.ZaloPayIncome;
            }
        }
    }
}
