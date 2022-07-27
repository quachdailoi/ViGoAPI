using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IAccountService
    {
        Task<int?> GetAccountIdBy(string userCode, RegistrationTypes registrationType);
    }
}
