using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileController : Controller
    {
        [Route("~/Admin/File")]
        [Route("~/Admin/File/FileManager")]
        public IActionResult FileManager()
        {
            return View();
        }
    }
}