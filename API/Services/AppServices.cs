using API.Services.Constract;

namespace API.Services
{
    public class AppServices : IAppServices
    {
        public AppServices(
                IAccountService accountService,
                IVerifiedCodeService verifiedCodeService,
                IUserService userService,
                ITokenService tokenService,
                IBookerService bookerService, 
                IDriverService driverService
            )
        {
            Account = accountService;
            VerifiedCode = verifiedCodeService;
            User = userService;
            Token = tokenService;
            Booker = bookerService;
            Driver = driverService;
        }

        public IAccountService Account { get; }
        public IVerifiedCodeService VerifiedCode { get; }
        public IUserService User { get; }
        public ITokenService Token { get; set; }
        public IBookerService Booker { get; }
        public IDriverService Driver { get; }
    }
}
