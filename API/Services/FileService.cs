using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using API.AWS.S3;
using API.Extensions;
using API.Models.Response;
using API.Services.Constract;
using Domain.Interfaces.UnitOfWork;
using System.Net.Mime;

namespace API.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        private readonly AmazonS3Client _s3Client;

        public FileService(IConfiguration configuration, IUnitOfWork unitOfWork, ILogger<FileService> logger)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _logger = logger;

            var credentials = new BasicAWSCredentials(_configuration.GetConfigByEnv("AwsSettings:AccessKey"), _configuration.GetConfigByEnv("AwsSettings:SecretKey"));
            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.APSoutheast1
            };
            _s3Client = new AmazonS3Client(credentials, config);
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

        public string? GetPresignedUrl(string fileName)
        {
            var request = new GetPreSignedUrlRequest()
            {
                BucketName = _configuration.GetConfigByEnv("AwsSettings:BucketName"),
                Key = fileName,
                Expires = DateTime.Now.AddHours(1),
                Verb = HttpVerb.GET,
                Protocol = Protocol.HTTPS
            };

            var presignedUrl = _s3Client.GetPreSignedURL(request);
            return presignedUrl;
        }
    }
}
