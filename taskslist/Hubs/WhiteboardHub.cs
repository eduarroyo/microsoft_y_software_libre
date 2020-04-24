using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace taskslist.Hubs
{
    public class WhiteboardHub : Hub
    {
        public Task Draw(int prevX, int prevY, int currentX, int currentY, string color)
        {
            return Clients.Others.SendAsync("draw", prevX, prevY, currentX, currentY, color);
        }
    }
}