using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace taskslist.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger): base(logger)
        { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
