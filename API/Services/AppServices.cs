using API.Services.Constract;
using Domain.Interfaces.Services;

namespace API.Services
{
    public class AppServices : IAppServices
    {
        public AppServices(
                IAccountService accountService,
                IAuthService authService,
                IVerifiedCodeService verifiedCodeService
            )
        {
            AccountService = accountService;
            AuthService = authService;
            VerifiedCodeService = verifiedCodeService;
        }

        public IAccountService AccountService { get; }
        public IAuthService AuthService { get; }
        public IVerifiedCodeService VerifiedCodeService { get; }

    }
}
