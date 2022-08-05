using API.Models;
using API.Models.Requests;
using Domain.Entities;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserViewModel> GetDriverUserViewModelByEmail(string email);

        Task<Account> GetDriverAccountByEmail(string email);

        Task<Account> GetBookerAccountByPhoneNumber(string phoneNumber);

        Task<Account> GetBookerAccountByEmail(string email);

        Task<Account> GetDriverAccountByPhoneNumber(string email);

        Task<UserViewModel> GetBookerUserViewModelByPhoneNumber(string phoneNumber);

        Task<UserViewModel> GetUserViewModelByRole(Roles role);
    }
}
