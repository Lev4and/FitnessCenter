using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IconsController : Controller
    {
        [Route("~/Admin/Icons/Boxicons")]
        public IActionResult BoxIcons()
        {
            return View();
        }
        
        [Route("~/Admin/Icons/FeatherIcons")]
        public IActionResult FeatherIcons()
        {
            return View();
        }
        
        [Route("~/Admin/Icons/LineIcons")]
        public IActionResult LineIcons()
        {
            return View();
        }
    }
}