using API.JwtFeatures;
using API.SignalR.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class SignalRService : ISignalRService
    {
        private readonly IHubContext<SignalRHub> _signalRHub;

        public SignalRService(IHubContext<SignalRHub> signalRHub)
        {
            _signalRHub = signalRHub;
        }

        public async Task SendAllAsync(string method, Object obj)
        {
            await _signalRHub.Clients.All.SendAsync(method, obj);
        }

        public async Task SendToUserAsync(string userCode, string method, Object obj)
        {
            await _signalRHub.Clients.Group(userCode).SendAsync(method, obj);
        }

        public async Task SendToUsersAsync(List<string> userCodes, string method, object obj)
        {
            await _signalRHub.Clients.Groups(userCodes).SendAsync(method, obj);
        }

        public async Task SendToUsersGroupRoleNameAsync(Roles role, string method, Object obj)
        {
            await _signalRHub.Clients.Group(role.GetString()).SendAsync(method, obj);
        }
    }
}
