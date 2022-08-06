using API.Models;
using API.SignalR.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class SignalRHub: Hub
    {
        public async Task Connect()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("Connected","Connect successfully");
        }

        public async Task Login(UserViewModel user)
        { 
            await Groups.AddToGroupAsync(Context.ConnectionId, user.Code.ToString());
            await Groups.AddToGroupAsync(Context.ConnectionId, user.RoleName);
        }

        public async Task Logout(UserViewModel user)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.Code.ToString());
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.RoleName);
        }

        public async Task Disconnect()
        {
        }
    }
}
