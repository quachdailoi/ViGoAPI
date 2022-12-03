using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using API.AWS.S3;
using API.Extensions;
using API.Models.Response;
using API.Models.SettingConfigs;
using API.Services.Constract;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using System.Net.Mime;

namespace API.Services
{
    public class FileService : BaseService, IFileService
    {
        private readonly AmazonS3Client _s3Client;
        private readonly ILogger<FileService> _logger;

        public FileService(IAppServices appServices) : base(appServices)
        {
            _logger = Logger<FileService>();

            var credentials = new BasicAWSCredentials(Configuration.Get(AwsSettings.AccessKey), Configuration.Get(AwsSettings.SecretKey));
            var clientConfig = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.APSoutheast1
            };
            _s3Client = new AmazonS3Client(credentials, clientConfig);
        }

        public async Task<Response> UploadFileAsync(S3ObjectDto obj, Response successResponse, Response errorResponse)
        {
            try
            {
                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    InputStream = obj.InputStream,
                    Key = obj.Name,
                    BucketName = obj.BucketName,
                    CannedACL = S3CannedACL.NoACL
                };

                // initialise the transfer/upload tools
                var transferUtility = new TransferUtility(_s3Client);

                // initiate the file upload
                await transferUtility.UploadAsync(uploadRequest);

                return successResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return errorResponse;
            }
        }

        public async Task<bool> UploadFileAsync(S3ObjectDto obj)
        {
            var uploadRS = await UploadFileAsync(obj, new() { Success = true }, new() { Success = false });

            return uploadRS.Success;
        }

        public async Task<AppFile?> UploadFileAsync(string path, IFormFile file, FileTypes fileType = FileTypes.AvatarImage)
        {
            var fileObj = new AppFile() { Type = fileType };
            // Process file
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var fileExt = Path.GetExtension(file.FileName);
            var docName = $"{path}{fileExt}";
            fileObj.Path = docName;

            fileObj = await UnitOfWork.Files.Add(fileObj);

            if (fileObj == null) return null;

            // call server
            var s3Obj = new S3ObjectDto()
            {
                BucketName = Configuration.Get(AwsSettings.BucketName) ?? "",
                InputStream = memoryStream,
                Name = docName
            };

            var result = await AppServices.File.UploadFileAsync(s3Obj);

            if (!result) return null;

            return fileObj;
        }

        public async Task<bool> UpdateS3File(string path, IFormFile file)
        {
            // Process file
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            // call server
            var s3Obj = new S3ObjectDto()
            {
                BucketName = Configuration.Get(AwsSettings.BucketName) ?? "",
                InputStream = memoryStream,
                Name = path
            };

            return await UploadFileAsync(s3Obj);
        }

        public string? GetPresignedUrl(string filePath)
        {
            if (filePath == null) return null;

            var request = new GetPreSignedUrlRequest()
            {
                BucketName = Configuration.Get(AwsSettings.BucketName),
                Key = filePath,
                Expires = DateTimeOffset.Now.AddHours(1).DateTime,
                Verb = HttpVerb.GET,
                Protocol = Protocol.HTTPS
            };

            var presignedUrl = _s3Client.GetPreSignedURL(request);
            return presignedUrl;
        }

        public async Task<string> GetFilePathById(int id)
        {
            return (await UnitOfWork.Files.GetById(id)).Path;
        }

        public string? GetPresignedUrl(AppFile? file)
        {
            if (file == null) return null;

            return GetPresignedUrl(file.Path);
        }
    }
}