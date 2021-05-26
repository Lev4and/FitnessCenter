using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmailController : Controller
    {
        [Route("~/Admin/Email")]
        [Route("~/Admin/Email/EmailBox")]
        public IActionResult EmailBox()
        {
            return View();
        }

        [Route("~/Admin/Email/EmailRead")]
        public IActionResult EmailRead()
        {
            return View();
        }
    }
}