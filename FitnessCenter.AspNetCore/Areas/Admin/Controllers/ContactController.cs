using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        [Route("~/Admin/Contact")]
        [Route("~/Admin/Contact/Contacts")]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}