﻿using API.AWS.S3;
using API.Extensions;
using API.Models;
using API.Models.Response;
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
        private readonly IConfiguration _configuration;
        private readonly IFileService _fileService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _fileService = fileService;
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

        public List<User> GetUsersByCode(List<Guid> userCodes)
        {

            var user = _unitOfWork.Users.GetUsersByCode(userCodes);

            return user.ToList();
        }

        public async Task<Response> UpdateUserAvatar(string userCode, IFormFile avatar, Response successResponse, Response errorResponse)
        {
            var user = await _unitOfWork.Users.GetUserByCode(userCode).Include(x => x.File).FirstOrDefaultAsync();
            var userFile = user.File;

            // Process file
            await using var memoryStream = new MemoryStream();
            await avatar.CopyToAsync(memoryStream);

            var fileExt = Path.GetExtension(avatar.FileName);
            var docName = $"{_configuration.GetConfigByEnv("AwsSettings:UserAvatarFolder")}{userCode}{fileExt}";

            // update file path
            await _unitOfWork.CreateTransactionAsync(); // open transaction

            userFile.Path = docName;

            if (!await _unitOfWork.Users.Update(user))
            {
                await _unitOfWork.Rollback(); // rollback
                return errorResponse;
            }

            // call server
            var s3Obj = new S3ObjectDto()
            {
                BucketName = _configuration.GetConfigByEnv("AwsSettings:BucketName") ?? "",
                InputStream = memoryStream,
                Name = docName
            };

            var result = await _fileService.UploadFileAsync(s3Obj, successResponse, errorResponse);

            if (!result.Success)
            {
                await _unitOfWork.Rollback(); // rollback
                return result;
            }

            await _unitOfWork.CommitAsync(); // commit
            return result;
        }
    }
}
