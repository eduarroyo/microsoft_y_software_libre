using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace taskslist.Hubs
{
    public class TasklistHub : Hub
    {
        private List<Models.Tareas> ReadTasks()
        {
            List<Models.Tareas> tasks;
            using(var context = new Context.TestContext())
            {
                tasks = context.Tareas.ToList();
            }

            return tasks;
        }

        public async Task AfterConnected()
        {
            List<Models.Tareas> tasks = ReadTasks();
            await Clients.Caller.SendAsync("listUpdated", tasks);
        }

        public async Task NewTask(string user, string task)
        {
            Models.Tareas newTask = new Models.Tareas
            {
                Tarea = task?.Trim(),
                CreadoFecha =  System.DateTime.Now,
                ModificadoFecha = System.DateTime.Now,
                Usuario = user?.Trim(),
                Resuelta = false                
            };

            using(var context = new Context.TestContext())
            {
                await context.Tareas.AddAsync(newTask);
                await context.SaveChangesAsync();
            }

            await Clients.All.SendAsync("taskAdded", newTask);
        }

        public async Task RemoveTask(long taskId)
        {
            Models.Tareas taskToRemove;
            using(var context = new Context.TestContext())
            {
                taskToRemove = await context.Tareas.FindAsync(taskId);
                if(taskToRemove != null)
                {
                    context.Remove(taskToRemove);
                    await context.SaveChangesAsync();
                }
            }

            await Clients.All.SendAsync("taskRemoved", taskId);
        }

        public async Task MarkAs(long taskId, bool done)
        {
            Models.Tareas taskToUpdate;
            using(var context = new Context.TestContext())
            {
                taskToUpdate = await context.Tareas.FindAsync(taskId);
                if(taskToUpdate != null)
                {
                    taskToUpdate.Resuelta = done;
                    taskToUpdate.ModificadoFecha = System.DateTime.Now;
                    context.Remove(taskToUpdate);
                    await context.SaveChangesAsync();
                }
            }

            await Clients.All.SendAsync("taskUpdated", taskToUpdate);
        }
    }
}