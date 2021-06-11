using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrainerServicesController : Controller
    {
        private readonly DataManager _dataManager;

        public TrainerServicesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var viewModel = new TrainerServicesViewModel()
            {
                TrainerServices = _dataManager.TrainerServices.GetTrainerServices().ToList()
            };

            return View(viewModel);
        }

        public IActionResult Save()
        {
            var viewModel = new TrainerServiceViewModel()
            {
                TrainerService = new TrainerService(),
                Services = _dataManager.Services.GetServicesWitchRequireATrainer().ToList(),
                Trainers = _dataManager.Trainers.GetTrainers().ToList()
            };

            return View(viewModel);
        }

        [Route("~/Admin/TrainerServices/Save/{id}")]
        public IActionResult Save(Guid id)
        {
            var viewModel = new TrainerServiceViewModel()
            {
                TrainerService = _dataManager.TrainerServices.GetTrainerServiceById(id),
                Services = _dataManager.Services.GetServicesWitchRequireATrainer().ToList(),
                Trainers = _dataManager.Trainers.GetTrainers().ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(TrainerServiceViewModel viewModel)
        {
            if (_dataManager.TrainerServices.SaveTrainerService(viewModel.TrainerService))
            {
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [Route("~/Admin/TrainerServices/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _dataManager.TrainerServices.DeleteTrainerServiceById(id);

            return RedirectToAction("Index");
        }
    }
}
