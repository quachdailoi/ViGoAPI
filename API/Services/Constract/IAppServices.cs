
namespace API.Services.Constract
{
    public interface IAppServices
    {
        IAccountService Account { get; }
        IVerifiedCodeService VerifiedCode { get; }
        IUserService User { get; }

        ITokenService Token { get; }

        IBookerService Booker { get; }

        IDriverService Driver { get; }
    }
}
