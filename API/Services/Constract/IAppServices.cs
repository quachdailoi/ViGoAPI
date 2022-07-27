using Domain.Interfaces.Services;

namespace API.Services.Constract
{
    public interface IAppServices
    {
        IAccountService AccountService { get; }
        IAuthService AuthService { get; }
        IVerifiedCodeService VerifiedCodeService { get; }
    }
}
