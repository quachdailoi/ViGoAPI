using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;

namespace API.Services
{
    public class AffiliateAccountService : IAffiliateAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AffiliateAccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Response> LinkAffiliateAccount(AffiliateAccountDTO dto, Response successResponse, Response errorResponse)
        {
            return  Task.FromResult(LinkAffiliateAccount(dto).Result ? successResponse : errorResponse);
        }

        public Task<bool> LinkAffiliateAccount(AffiliateAccountDTO dto)
        {
            var affiliateAccount = _mapper.Map<AffiliateAccount>(dto);

            return Task.FromResult(_unitOfWork.AffiliateAccounts.Add(affiliateAccount).Result != null);
        }
    }
}
