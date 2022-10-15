using API.Extensions;
using API.Models;
using AutoMapper;
using Domain.Entities;

namespace API.Mapper
{
    public class WalletTransactionMappingProfile : Profile
    {
        public WalletTransactionMappingProfile()
        {
            CreateMap<WalletTransaction, WalletTransactionViewModel>()
                .ForMember(
                    dest => dest.TypeName,
                    opt => opt.MapFrom(
                        src => src.Type.DisplayName()))
                .ForMember(
                    dest => dest.StatusName,
                    opt => opt.MapFrom(
                        src => src.Status.DisplayName()))
                .ForMember(
                    dest => dest.Time,
                    opt => opt.MapFrom(
                        src => src.UpdatedAt.ToFormatString()));
        }
    }
}
