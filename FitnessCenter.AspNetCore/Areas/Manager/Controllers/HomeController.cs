using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class HomeController : Controller
    {
        [Route("~/Manager")]
        [Route("~/Manager/Home")]
        [Route("~/Manager/Home/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
