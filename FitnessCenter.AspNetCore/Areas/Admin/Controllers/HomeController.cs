using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("~/Admin")]
        [Route("~/Admin/Home")]
        [Route("~/Admin/Home/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
