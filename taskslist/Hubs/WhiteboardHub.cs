using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace taskslist.Hubs
{
    public class WhiteboardHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}