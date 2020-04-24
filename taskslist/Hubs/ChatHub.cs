using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using taskslist.Context;
using taskslist.Models;

namespace taskslist.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);

            using(var context = new TestContext())
            {
                var mensajeNuevo = new Mensajes
                {
                    Mensaje = message,
                    FechaEnvio = System.DateTime.Now,
                    Remitente = user
                };

                await context.Mensajes.AddAsync(mensajeNuevo);
                await context.SaveChangesAsync();
            }
        }
    }
}