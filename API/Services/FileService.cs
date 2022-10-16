using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using API.AWS.S3;
using API.Extensions;
using API.Models.Response;
using API.Models.Settings;
using API.Services.Constract;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
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