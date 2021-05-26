using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContentController : Controller
    {
        [Route("~/Admin/Content/GridSystem")]
        public IActionResult GridSystem()
        {
            return View();
        }

        [Route("~/Admin/Content/TextUtilities")]
        public IActionResult TextUtilities()
        {
            return View();
        }

        [Route("~/Admin/Content/Typography")]
        public IActionResult Typography()
        {
            return View();
        }
    }
}