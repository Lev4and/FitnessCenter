using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetsController : Controller
    {
        [Route("~/Admin/Widgets")]
        [Route("~/Admin/Widgets/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}