using Amazon.Runtime.Internal;
using Amazon.S3.Model.Internal.MarshallTransformations;
using API.AWS.S3;
using API.Extensions;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Settings;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using FirebaseAdmin.Auth;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IAppServices appServices) : base(appServices)
        {
        }

        public Task<bool> UpdateUser(User user)
        {
            return UnitOfWork.Users.Update(user);
        }

        public IQueryable<User>? GetUserById(int? id)
        {
            if (id == null) return null;

            var user = UnitOfWork.Users.GetUserById((int)id);

            return user;
        }

        public User? GetById(int? id)
        {
            if (id == null) return null;

            var user = UnitOfWork.Users.GetUserById((int)id).FirstOrDefault();

            return user;
        }

        public async Task<UserViewModel?> GetUserViewModelById(int? userId)
        {
            if (userId == null) return null;

            var roles = UnitOfWork.Roles.GetAllRoles();

            var account = await UnitOfWork.Accounts.GetAccountByUserId((int)userId).Where(acc => acc.RoleId != null).FirstOrDefaultAsync();

            if (account == null) return null;

            var user = UnitOfWork.Users.List(user => user.Id == account.UserId);

            return await user.MapTo<UserViewModel>(Mapper, AppServices).FirstOrDefaultAsync();
        }

        public List<User> GetUsersByCode(List<Guid> userCodes)
        {
            var user = UnitOfWork.Users.GetUsersByCode(userCodes);

            return user.ToList();
        }

        public async Task<Response> UpdateUserAvatar(string userCode, IFormFile avatar, Response successResponse, Response errorResponse)
        {
            var user = await UnitOfWork.Users.GetUserByCode(userCode).Include(x => x.File).FirstOrDefaultAsync();
            var userFile = user.File;

            // Process file
            await using var memoryStream = new MemoryStream();
            await avatar.CopyToAsync(memoryStream);

            var fileExt = Path.GetExtension(avatar.FileName);
            var docName = $"{Configuration.Get(AwsSettings.UserAvatarFolder)}{userCode}{fileExt}";

            // update file path
            await UnitOfWork.CreateTransactionAsync(); // open transaction

            userFile.Path = docName;

            if (!await UnitOfWork.Users.Update(user))
            {
                await UnitOfWork.Rollback(); // rollback
                return errorResponse;
            }

            // call server
            var s3Obj = new S3ObjectDto()
            {
                BucketName = Configuration.Get(AwsSettings.BucketName) ?? "",
                InputStream = memoryStream,
                Name = docName
            };

            var result = await AppServices.File.UploadFileAsync(s3Obj, successResponse, errorResponse);

            if (!result.Success)
            {
                await UnitOfWork.Rollback(); // rollback
                return result;
            }

            await UnitOfWork.CommitAsync(); // commit
            return result;
        }

        public async Task<AppFile?> UpdateUserAvatar(string userCode, IFormFile avatar)
        {
            var user = await UnitOfWork.Users.GetUserByCode(userCode).Include(x => x.File).FirstOrDefaultAsync();

            var userFile = user?.File ?? new AppFile();

            // Process file
            await using var memoryStream = new MemoryStream();
            await avatar.CopyToAsync(memoryStream);

            var fileExt = Path.GetExtension(avatar.FileName);
            var docName = $"{Configuration.Get(AwsSettings.UserAvatarFolder)}{userCode}{fileExt}";

            userFile.Path = docName;

            if (!await UnitOfWork.Users.Update(user)) return null;

            // call server
            var s3Obj = new S3ObjectDto()
            {
                BucketName = Configuration.Get(AwsSettings.BucketName) ?? "",
                InputStream = memoryStream,
                Name = docName
            };

            var result = await AppServices.File.UploadFileAsync(s3Obj);

            if (!result) return null;

            return userFile;
        }

        public async Task<Response> GetEmailWithFireBaseAuthAsync(LoginByEmailRequest request)
        {
            FirebaseAuth firebaseAuth = FirebaseAuth.DefaultInstance;

            FirebaseToken verifiedIdToken = await firebaseAuth.VerifyIdTokenAsync(request.IdToken);

            if (verifiedIdToken == null)
            {
                return new()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Login failed - Something went wrong.",
                    Success = false
                };
            }

            IReadOnlyDictionary<string, dynamic> claims = verifiedIdToken.Claims;

            string gmail = claims["email"];

            return new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Get email from firebase auth successfully.",
                Data = gmail
            };
        }

        public Task<List<User>> GetByRole(Roles role) => UnitOfWork.Users.List(user => user.Accounts.Select(acc => acc.Role).First().Id == role).ToListAsync();

        public Task CreateRange(List<User> users) => UnitOfWork.Users.Add(users);

        public Task CheckValidUserToLogin(UserViewModel userVm, RegistrationTypes registrationType)
        {
            var user = AppServices.User.GetUserById(userVm.Id)?.Include(x => x.Accounts).FirstOrDefault();

            if (user == null) throw new Exception("Login failed, not found user. Please try again.");

            if (user.Status != Users.Status.Active) throw new Exception("Login failed, user is not active to login.");

            var accLogin = user.Accounts.Where(x => x.RegistrationType == registrationType).FirstOrDefault();

            if (accLogin == null) throw new Exception("Login failed, not found account. Please try again.");

            if (!accLogin.Verified) throw new Exception("Login failed, account was not verified to login.");

            return Task.CompletedTask;
        }

        public async Task<bool?> UpdateStatus(int userId, Users.Status status)
        {
            var user = await UnitOfWork.Users.List(x => x.Id == userId).FirstOrDefaultAsync();

            if (user == null) return null;

            user.Status = status;

            return await UnitOfWork.Users.Update(user);
        }
    }
}
