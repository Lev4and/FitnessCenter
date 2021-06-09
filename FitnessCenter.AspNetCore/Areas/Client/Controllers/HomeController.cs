using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        [Route("~/Client")]
        [Route("~/Client/Home")]
        [Route("~/Client/Home/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
