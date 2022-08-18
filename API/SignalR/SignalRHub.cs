using API.Models;
using API.SignalR.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class SignalRHub:Hub
    {
        private async Task Connect()
        {
            //await Groups.AddToGroupAsync(Context.ConnectionId, Context.ConnectionId);
            await Clients.Client(Context.ConnectionId).SendAsync("Connected","Connect successfully");
        }

        private async Task Login(UserViewModel user)
        { 
            await Groups.AddToGroupAsync(Context.ConnectionId, user.Code.ToString());
            await Groups.AddToGroupAsync(Context.ConnectionId, user.RoleName);
        }

        private async Task Logout(UserViewModel user)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.Code.ToString());
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.RoleName);
        }

        private async Task Disconnect()
        {
        }
    }
}
