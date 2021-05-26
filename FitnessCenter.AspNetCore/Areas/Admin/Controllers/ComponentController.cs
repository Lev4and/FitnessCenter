using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ComponentController : Controller
    {
        [Route("~/Admin/Component/Alerts")]
        public IActionResult Alerts()
        {
            return View();
        }

        [Route("~/Admin/Component/Badge")]
        public IActionResult Badge()
        {
            return View();
        }

        [Route("~/Admin/Component/Buttons")]
        public IActionResult Buttons()
        {
            return View();
        }

        [Route("~/Admin/Component/Cards")]
        public IActionResult Cards()
        {
            return View();
        }

        [Route("~/Admin/Component/Carousel")]
        public IActionResult Carousel()
        {
            return View();
        }
        
        [Route("~/Admin/Component/Acordians")]
        public IActionResult Acordians()
        {
            return View();
        }

        [Route("~/Admin/Component/ListGroups")]
        public IActionResult ListGroups()
        {
            return View();
        }

        [Route("~/Admin/Component/MediaObjects")]
        public IActionResult MediaObjects()
        {
            return View();
        }

        [Route("~/Admin/Component/Modal")]
        public IActionResult Modal()
        {
            return View();
        }

        [Route("~/Admin/Component/Navs")]
        public IActionResult Navs()
        {
            return View();
        }

        [Route("~/Admin/Component/Navbar")]
        public IActionResult Navbar()
        {
            return View();
        }

        [Route("~/Admin/Component/Pagination")]
        public IActionResult Pagination()
        {
            return View();
        }

        [Route("~/Admin/Component/PopoversTooltips")]
        public IActionResult PopoversTooltips()
        {
            return View();
        }

        [Route("~/Admin/Component/Progress")]
        public IActionResult Progress()
        {
            return View();
        }

        [Route("~/Admin/Component/Spinners")]
        public IActionResult Spinners()
        {
            return View();
        }

        [Route("~/Admin/Component/Notifications")]
        public IActionResult Notifications()
        {
            return View();
        }

        [Route("~/Admin/Component/AvatrsChips")]
        public IActionResult AvatrsChips()
        {
            return View();
        }
    }
}