using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("~/Admin")]
        [Route("~/Admin/Home")]
        [Route("~/Admin/Home/Analytics")]
        public IActionResult Analytics()
        {
            return View();
        }

        [Route("~/Admin/Home/Sales")]
        public IActionResult Sales()
        {
            return View();
        }
    }
}
