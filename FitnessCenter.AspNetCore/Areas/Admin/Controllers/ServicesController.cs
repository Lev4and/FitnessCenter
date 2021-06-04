using FitnessCenter.AspNetCore.Models;
using FitnessCenter.AspNetCore.Services;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        private readonly DataManager _dataManager;
        private readonly UploadFileService _uploadFileService;

        public ServicesController(IWebHostEnvironment appEnvironment, DataManager dataManager, UploadFileService uploadFileService)
        {
            _appEnvironment = appEnvironment;

            _dataManager = dataManager;
            _uploadFileService = uploadFileService;
        }

        public IActionResult Index()
        {
            var viewModel = new ServicesViewModel()
            {
                Services = _dataManager.Services.GetServices().ToList()
            };

            return View(viewModel);
        }

        public IActionResult Save()
        {
            var viewModel = new ServiceViewModel()
            {
                Service = new Service(),
                Categories = _dataManager.ServiceCategories.GetServiceCategories().ToList()
            };

            return View(viewModel);
        }

        [Route("~/Admin/Services/Save/{id}")]
        public IActionResult Save(Guid id)
        {
            var viewModel = new ServiceViewModel()
            {
                Service = _dataManager.Services.GetServiceById(id),
                Categories = _dataManager.ServiceCategories.GetServiceCategories().ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(ServiceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_dataManager.Services.SaveService(viewModel.Service))
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(nameof(viewModel.Service.CategoryId), "Услуга с такими данными уже существует");
                ModelState.AddModelError(nameof(viewModel.Service.Name), "Услуга с такими данными уже существует");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadCKEditor(IFormFile upload)
        {
            if (await _uploadFileService.UploadFileAsync(upload, "/images/upload/services/"))
            {
                return new JsonResult(new { uploaded = 1, fileName = upload.FileName, url = $"/images/upload/services/{upload.FileName}" });
            }

            return new JsonResult(new { uploaded = 0 });
        }

        [HttpGet]
        public IActionResult FileBrowse()
        {
            var viewModel = new BrowseFilesViewModel()
            {
                Files = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _appEnvironment.WebRootPath,
                                    @"images\upload\services")).GetFiles().ToList()
            };

            return View("FileBrowsePartial", viewModel);
        }

        [Route("~/Admin/Services/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Services.DeleteServiceById(id);

            return RedirectToAction("Index");
        }
    }
}
