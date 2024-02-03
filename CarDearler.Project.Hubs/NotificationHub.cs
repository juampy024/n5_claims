using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace N5_API.Project.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task InitializeConnectionMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", "Connection id: " + message);
        }

    }
}
