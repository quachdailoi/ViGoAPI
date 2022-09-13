using API.Helpers.Attributes;
using API.JwtFeatures;
using API.Models;
using API.SignalR.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class SignalRHub : Hub
    {
        private readonly IJwtHandler _jwtHandler;
        public SignalRHub(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }
        [CustomAuthorize]
        public async Task Login()
        {
            var token = Context.GetHttpContext()?.Request.Query["access_token"].FirstOrDefault();

            var user = await _jwtHandler.GetUserViewModelByToken(token);

            await Groups.AddToGroupAsync(Context.ConnectionId, user.Code.ToString());
            await Groups.AddToGroupAsync(Context.ConnectionId, user.RoleName);

            await Clients.Client(Context.ConnectionId).SendAsync("User", user);
        }

        [CustomAuthorize]
        public async Task Logout()
        {
            var token = Context.GetHttpContext()?.Request.Query["access_token"].FirstOrDefault();

            var user = await _jwtHandler.GetUserViewModelByToken(token);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.Code.ToString());
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.RoleName);
        }

        public override Task OnConnectedAsync()
        {
            Clients.Client(Context.ConnectionId).SendAsync("Connected", "Connect successfully");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (exception != null)
            {
                System.Console.WriteLine($"Exception on disconnect from signalr client: {exception.Message}");
            }
            else
            {
                System.Console.WriteLine($"A client has disconnected: {Context.ConnectionId}");
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
