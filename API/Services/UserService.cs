using API.Models;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<bool> UpdateUser(User user)
        {
            return _unitOfWork.Users.Update(user);
        }

        public IQueryable<User>? GetUserById(int? id)
        {
            if (id == null) return null;

            var user = _unitOfWork.Users.GetUserById((int)id);

            return user;
        }

        public async Task<UserViewModel?> GetUserViewModelById(int? userId)
        {
            if (userId == null) return null;

            var roles = _unitOfWork.Roles.GetAllRoles();

            var account = await _unitOfWork.Accounts.GetAccountByUserId((int)userId).Where(acc => acc.RoleId != null).FirstOrDefaultAsync();

            if (account == null) return null;

            var user = _unitOfWork.Users.List(user => user.Id == account.UserId);

            return await _mapper.ProjectTo<UserViewModel>(user).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsersByCode(List<Guid> userCodes)
        {

            var user = _unitOfWork.Users.GetUsersByCode(userCodes);

            return await user.ToListAsync();
        }
    }
}
