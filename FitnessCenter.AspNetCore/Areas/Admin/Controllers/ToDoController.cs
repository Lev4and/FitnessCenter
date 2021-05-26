using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ToDoController : Controller
    {
        [Route("~/Admin/ToDo")]
        [Route("~/Admin/ToDo/ToDoList")]
        public IActionResult ToDoList()
        {
            return View();
        }
    }
}