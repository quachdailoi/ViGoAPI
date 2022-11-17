﻿using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IReportService
    {
        Task<Response> Get(PagingRequest request, Response response, Reports.Status? status = null);
        Task<bool?> UpdateStatus(Guid code, Reports.Status status);
        Task<Response> GetData(Guid code, Response successResponse, Response notFoundResponse);
        Task<Response> Create(ReportDTO reportDTO, Response successResponse, Response failResponse);
    }
}