using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace taskslist.Controllers
{
    public class ChatController : BaseController
    {
        public ChatController(ILogger<ChatController> logger): base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
