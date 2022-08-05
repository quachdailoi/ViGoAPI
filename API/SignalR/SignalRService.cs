using API.SignalR.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class SignalRService : SignalRHub, ISignalRService
    {
        public async Task SendAllAsync(string method, Object obj)
        {
            await Clients.All.SendAsync(method, obj);
        }

        public async Task SendToUserAsync(string userCode, string method, Object obj)
        {
            await Clients.Group(userCode).SendAsync(method, obj);
        }

        public async Task SendToUsersGroupRoleNameAsync(Roles role, string method, Object obj)
        {
            await Clients.Group(role.GetString()).SendAsync(method, obj);
        }
    }
}
