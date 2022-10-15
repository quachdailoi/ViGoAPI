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
                        src => GetWalletTopUpTransactionType(src.Type)));

            CreateMap<Wallet, WalletViewModel>();
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
