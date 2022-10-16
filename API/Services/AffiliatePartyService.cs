using API.Services.Constract;

namespace API.Services
{
    public class AffiliatePartyService : BaseService, IAffiliatePartyService
    {
        public AffiliatePartyService(IAppServices appServices) : base(appServices)
        {
        }
    }
}
