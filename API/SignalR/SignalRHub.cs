using API.Models;
using API.SignalR.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class SignalRHub: Hub
    {
        [Authorize]
        public async Task Login()
        {
            var claims = Context.User.Claims;

            var userClaim = claims.Where(claim => claim.Type == "User").FirstOrDefault().Value;

            var user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserViewModel>(userClaim);

            await Groups.AddToGroupAsync(Context.ConnectionId, user.Code.ToString());
            await Groups.AddToGroupAsync(Context.ConnectionId, user.RoleName);

            await Clients.Client(Context.ConnectionId).SendAsync("User", user);
        }

        [Authorize]
        public async Task Logout()
        {
            var claims = Context.User.Claims;

            var userClaim = claims.Where(claim => claim.Type == "User").FirstOrDefault().Value;

            var user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserViewModel>(userClaim);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.Code.ToString());
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, user.RoleName);
        }

        public override Task OnConnectedAsync()
        {
            Clients.Client(Context.ConnectionId).SendAsync("Connected", "Connect successfully");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
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
