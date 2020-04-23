using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace taskslist.Controllers
{
    public class TasklistController : BaseController
    {
        public TasklistController(ILogger<TasklistController> logger): base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
