using API.AWS.S3;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IFileService
    {
        Task<Response> UploadFileAsync(S3ObjectDto obj, Response successResponse, Response errorResponse);
        string? GetPresignedUrl(string filePath);
        string? GetPresignedUrl(AppFile? file);

        Task<string> GetFilePathById(int id);
    }
}
