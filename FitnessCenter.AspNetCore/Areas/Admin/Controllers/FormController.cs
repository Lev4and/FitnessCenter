using Microsoft.AspNetCore.Mvc;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FormController : Controller
    {
        [Route("~/Admin/Form/FormElements")]
        public IActionResult FormElements()
        {
            return View();
        }
        
        [Route("~/Admin/Form/InputGroups")]
        public IActionResult InputGroups()
        {
            return View();
        }
        
        [Route("~/Admin/Form/FormsLayouts")]
        public IActionResult FormsLayouts()
        {
            return View();
        }
        
        [Route("~/Admin/Form/FormValidation")]
        public IActionResult FormValidation()
        {
            return View();
        }
        
        [Route("~/Admin/Form/FormWizard")]
        public IActionResult FormWizard()
        {
            return View();
        }
        
        [Route("~/Admin/Form/TextEditor")]
        public IActionResult TextEditor()
        {
            return View();
        }
        
        [Route("~/Admin/Form/FileUpload")]
        public IActionResult FileUpload()
        {
            return View();
        }
        
        [Route("~/Admin/Form/DatePickers")]
        public IActionResult DatePickers()
        {
            return View();
        }
        
        [Route("~/Admin/Form/Select2")]
        public IActionResult Select2()
        {
            return View();
        }
    }
}