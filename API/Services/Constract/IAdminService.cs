using API.Models;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IAdminService : IAccountService
    {
        Task<UserViewModel?> GetUserViewModel(string registration, RegistrationTypes registrationTypes);
    }
}
