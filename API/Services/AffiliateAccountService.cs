using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;

namespace API.Services
{
    public class AffiliateAccountService : BaseService, IAffiliateAccountService
    {
        public AffiliateAccountService(IAppServices appServices) : base(appServices)
        {
        }

        public Task<Response> LinkAffiliateAccount(AffiliateAccountDTO dto, Response successResponse, Response errorResponse)
        {
            return  Task.FromResult(LinkAffiliateAccount(dto).Result ? successResponse : errorResponse);
        }

        public Task<bool> LinkAffiliateAccount(AffiliateAccountDTO dto)
        {
            var affiliateAccount = Mapper.Map<AffiliateAccount>(dto);

            return Task.FromResult(UnitOfWork.AffiliateAccounts.Add(affiliateAccount).Result != null);
        }
    }
}
