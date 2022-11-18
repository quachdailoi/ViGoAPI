using API.AWS.S3;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IFileService
    {
        Task<Response> UploadFileAsync(S3ObjectDto obj, Response successResponse, Response errorResponse);

        Task<bool> UploadFileAsync(S3ObjectDto obj);
        string? GetPresignedUrl(string filePath);
        string? GetPresignedUrl(AppFile? file);

        Task<string> GetFilePathById(int id);

        Task<AppFile?> UploadFileAsync(string path, IFormFile file, FileTypes fileType = FileTypes.AvatarImage);
        Task<bool> UpdateS3File(string path, IFormFile file);
    }
}
