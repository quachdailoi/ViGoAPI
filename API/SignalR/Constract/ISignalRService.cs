using API.JwtFeatures;
using Domain.Shares.Enums;

namespace API.SignalR.Constract
{
    public interface ISignalRService
    {
        Task SendAllAsync(string method, Object obj);
        Task SendToUserAsync(string userCode, string method, Object obj);
        Task SendToUsersAsync(List<string> userCodes, string method, Object obj);
        Task SendToUsersGroupRoleNameAsync(Roles role, string method, Object obj);

        Task SendToGroupAsync(string groupName, string method, Object obj);
    }
}
