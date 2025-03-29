using Microsoft.AspNetCore.SignalR;

namespace CustomPowerPoint.Hubs
{
    public class PresentationHub : Hub
    {
        private static readonly HashSet<string> ConnectedUsers = new();

        public override async Task OnConnectedAsync()
        {
            var user = Context.GetHttpContext()?.Request.Query["nickname"];
            if (!string.IsNullOrEmpty(user))
            {
                ConnectedUsers.Add(user);
            }
            await SendUserList();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var user = Context.GetHttpContext()?.Request.Query["nickname"];
            if (!string.IsNullOrEmpty(user))
            {
                ConnectedUsers.Remove(user);
            }
            await SendUserList();
            await base.OnDisconnectedAsync(exception);
        }

        private async Task SendUserList()
        {
            await Clients.All.SendAsync("UpdateUserList", ConnectedUsers.ToList());
        }

    }
}
