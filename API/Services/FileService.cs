﻿using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using API.AWS.S3;
using API.Extensions;
using API.Models.Response;
using API.Models.Settings;
using API.Services.Constract;
using Domain.Interfaces.UnitOfWork;
using System.Net.Mime;

namespace API.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        private readonly AmazonS3Client _s3Client;

        public FileService(IConfiguration config, IUnitOfWork unitOfWork, ILogger<FileService> logger)
        {
            _config = config;
            _unitOfWork = unitOfWork;
            _logger = logger;

            var credentials = new BasicAWSCredentials(_config.Get(AwsSettings.AccessKey), _config.Get(AwsSettings.SecretKey));
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

        public string? GetPresignedUrl(string fileName)
        {
            var request = new GetPreSignedUrlRequest()
            {
                BucketName = _config.Get(AwsSettings.BucketName),
                Key = fileName,
                Expires = DateTimeOffset.Now.AddHours(1).DateTime,
                Verb = HttpVerb.GET,
                Protocol = Protocol.HTTPS
            };

            var presignedUrl = _s3Client.GetPreSignedURL(request);
            return presignedUrl;
        }
    }
}
