using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace taskslist.Controllers
{
    public class WhiteboardController : BaseController
    {
        public WhiteboardController(ILogger<WhiteboardController> logger): base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
