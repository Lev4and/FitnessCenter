using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CalendarController : Controller
    {
        [Route("~/Admin/Calendar/FullCalendar")]
        public IActionResult FullCalendar()
        {
            return View();
        }
    }
}