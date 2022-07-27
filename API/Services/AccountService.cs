using API.Services.Constract;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int?> GetAccountIdBy(string userCode, RegistrationTypes registrationType)
        {
            var user = await _unitOfWork.Users.GetUserByCode(userCode).FirstOrDefaultAsync();

            var account = user.Accounts.Where(x => x.RegistrationType == ((int) registrationType)).FirstOrDefault();

            return account.Id;
        }
    }
}
