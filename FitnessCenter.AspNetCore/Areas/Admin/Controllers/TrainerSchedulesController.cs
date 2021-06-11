using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrainerSchedulesController : Controller
    {
        private readonly DataManager _dataManager;

        public TrainerSchedulesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var viewModel = new TrainerSchedulesViewModel()
            {
                TrainerSchedules = _dataManager.TrainerSchedules.GetTrainerSchedules().ToList()
            };

            return View(viewModel);
        }

        public IActionResult Save()
        {
            var viewModel = new TrainerScheduleViewModel()
            {
                TrainerSchedule = new TrainerSchedule(),
                Trainers = _dataManager.Trainers.GetTrainers().ToList(),
                DaysOfWeek = _dataManager.DaysOfWeek.GetDaysOfWeek().ToList()
            };

            return View(viewModel);
        }

        [Route("~/Admin/TrainerSchedules/Save/{id}")]
        public IActionResult Save(Guid id)
        {
            var viewModel = new TrainerScheduleViewModel()
            {
                TrainerSchedule = _dataManager.TrainerSchedules.GetTrainerScheduleById(id),
                DaysOfWeek = _dataManager.DaysOfWeek.GetDaysOfWeek().ToList(),
                Trainers = _dataManager.Trainers.GetTrainers().ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(TrainerScheduleViewModel viewModel)
        {
            if(viewModel.TrainerSchedule.From < viewModel.TrainerSchedule.Until)
            {
                if (_dataManager.TrainerSchedules.SaveTrainerSchedule(viewModel.TrainerSchedule))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(viewModel);
        }

        [Route("~/Admin/TrainerSchedules/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _dataManager.TrainerSchedules.DeleteTrainerScheduleById(id);

            return RedirectToAction("Index");
        }
    }
}
