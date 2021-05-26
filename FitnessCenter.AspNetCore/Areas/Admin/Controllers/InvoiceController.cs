using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoiceController : Controller
    {
        [Route("~/Admin/Invoice")]
        [Route("~/Admin/Invoice/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}