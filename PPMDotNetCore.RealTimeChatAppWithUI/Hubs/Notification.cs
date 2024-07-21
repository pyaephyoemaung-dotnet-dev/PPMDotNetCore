using Microsoft.AspNetCore.SignalR;

namespace PPMDotNetCore.RealTimeChatAppWithUI.Hubs
{
    public class Notification : Hub
    {
        public async Task ServerReceiveMessage(string user, string message)
        {
            await Clients.All.SendAsync("ClientReceiveMessage", user, message);
        }
    }
}
