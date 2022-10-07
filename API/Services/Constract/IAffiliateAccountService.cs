using API.Models.DTO;
using API.Models.Response;

namespace API.Services.Constract
{
    public interface IAffiliateAccountService
    {
        Task<Response> LinkAffiliateAccount(AffiliateAccountDTO dto, Response successResponse, Response errorResponse);
        Task<bool> LinkAffiliateAccount(AffiliateAccountDTO dto);
    }
}
