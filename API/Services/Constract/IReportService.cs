using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IReportService
    {
        Response Get(PagingRequest? request, Response response, string searchValue);
        Task<bool?> UpdateStatus(int userId, Guid code, Reports.Status status);
        Task<Response> GetData(Guid code, Response successResponse, Response notFoundResponse);
        Task<Response> Create(ReportDTO reportDTO, Response successResponse, Response failResponse);
    }
}
