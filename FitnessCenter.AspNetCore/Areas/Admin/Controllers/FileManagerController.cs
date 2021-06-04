using FitnessCenter.AspNetCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileManagerController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public FileManagerController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public IActionResult Browse()
        {
            var viewModel = new BrowseFilesViewModel()
            {
                Files = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _appEnvironment.WebRootPath, 
                    @"images\upload\blog")).GetFiles().ToList()
            };
            return View(viewModel);
        }
    }
}
