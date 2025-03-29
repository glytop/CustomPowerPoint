using Microsoft.AspNetCore.SignalR;

namespace CustomPowerPoint.Hubs
{
    public class PresentationHub : Hub
    {
        public async Task UpdateSlide(string presentationId, string slideId, string elementId, string newContent)
        {
            await Clients.OthersInGroup(presentationId).SendAsync("ReceiveSlideUpdate", slideId, elementId, newContent);
        }

        public async Task JoinPresentation(string presentationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, presentationId);
        }

        public async Task LeavePresentation(string presentationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, presentationId);
        }

    }
}
