using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChatController : Controller
    {
        [Route("~/Admin/Chat")]
        [Route("~/Admin/Chat/ChatBox")]
        public IActionResult ChatBox()
        {
            return View();
        }
    }
}