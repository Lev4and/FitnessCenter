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
    public class TrainersController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        private readonly DataManager _dataManager;
        private readonly UploadFileService _uploadFileService;

        public TrainersController(IWebHostEnvironment appEnvironment, DataManager dataManager, UploadFileService uploadFileService)
        {
            _appEnvironment = appEnvironment;

            _dataManager = dataManager;
            _uploadFileService = uploadFileService;
        }

        public IActionResult Index()
        {
            var viewModel = new TrainersViewModel()
            {
                Trainers = _dataManager.Trainers.GetTrainers().ToList()
            };

            return View(viewModel);
        }

        public IActionResult Save()
        {
            var viewModel = new TrainerViewModel()
            {
                Trainer = new Trainer() { DateOfBirth = DateTime.Now.AddYears(-18) },
                Genders = _dataManager.Genders.GetGenders().ToList(),
                TrainerCategories = _dataManager.TrainerCategories.GetTrainerCategories().ToList()
            };

            return View(viewModel);
        }

        [Route("~/Admin/Trainers/Save/{id}")]
        public IActionResult Save(Guid id)
        {
            var viewModel = new TrainerViewModel()
            {
                Trainer = _dataManager.Trainers.GetTrainerById(id),
                Genders = _dataManager.Genders.GetGenders().ToList(),
                TrainerCategories = _dataManager.TrainerCategories.GetTrainerCategories().ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TrainerViewModel viewModel, IFormFile uploadedFile)
        {
            if(uploadedFile != null)
            {
                if (await _uploadFileService.UploadFileAsync(uploadedFile, "/images/upload/trainers"))
                {
                    viewModel.Trainer.Photo = $"images/upload/trainers/{uploadedFile.FileName}";
                }
            }

            if (_dataManager.Trainers.SaveTrainer(viewModel.Trainer))
            {
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadCKEditor(IFormFile upload)
        {
            if(await _uploadFileService.UploadFileAsync(upload, "/images/upload/trainers/"))
            {
                return new JsonResult(new { uploaded = 1, fileName = upload.FileName, url = $"/images/upload/trainers/{upload.FileName}" });
            }

            return new JsonResult(new { uploaded = 0 });
        }

        [HttpGet]
        public IActionResult FileBrowse()
        {
            var viewModel = new BrowseFilesViewModel()
            {
                Files = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _appEnvironment.WebRootPath,
                @"images\upload\trainers")).GetFiles().ToList()
            };

            return View("FileBrowsePartial", viewModel);
        }

        [Route("~/Admin/Trainers/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Trainers.DeleteTrainerById(id);

            return RedirectToAction("Index");
        }
    }
}
