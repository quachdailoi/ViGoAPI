﻿using API.Models;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IUserService
    {
        Task<bool> UpdateUser(User user);
        IQueryable<User>? GetUserById(int? id);
        Task<UserViewModel?> GetUserViewModelById(int? userId);
        List<User> GetUsersByCode(List<Guid> userCodes);
        Task<Response> UpdateUserAvatar(string userCode, IFormFile file, Response successResponse, Response errorResponse);
    }
}
