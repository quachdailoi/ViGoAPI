using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;

namespace API.Services
{
    public class AdminService : AccountService, IAdminService
    {
        public AdminService(IVerifiedCodeService verifiedCodeService, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IUserService userService) : base(verifiedCodeService, unitOfWork, mapper, configuration, userService)
        {
        }

        public Task<UserViewModel?> GetUserViewModel(string registration, RegistrationTypes registrationTypes)
        {
            return base.GetUserViewModel(Roles.ADMIN, registration, registrationTypes);
        }
    }
}
