using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;

namespace API.Services
{
    public class AdminService : AccountService, IAdminService
    {
        public AdminService(IAppServices appServices) : base(appServices)
        {
        }

        public Task<UserViewModel?> GetUserViewModel(string registration, RegistrationTypes registrationTypes)
        {
            return GetUserViewModel(Roles.ADMIN, registration, registrationTypes);
        }
    }
}
