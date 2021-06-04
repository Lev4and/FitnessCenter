using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrainerCategoriesController : Controller
    {
        private readonly DataManager _dataManager;

        public TrainerCategoriesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var viewModel = new TrainerCategoriesViewModel()
            {
                TrainerCategories = _dataManager.TrainerCategories.GetTrainerCategories().ToList()
            };

            return View(viewModel);
        }

        public IActionResult Save()
        {
            return View(new TrainerCategory());
        }

        [Route("~/Admin/TrainerCategories/Save/{id}")]
        public IActionResult Save(Guid id)
        {
            return View(_dataManager.TrainerCategories.GetTrainerCategoryById(id));
        }

        [HttpPost]
        public IActionResult Save(TrainerCategory viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_dataManager.TrainerCategories.SaveTrainerCategory(viewModel))
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(nameof(viewModel.Name), "Категория тренера с такими данными уже существует");
            }

            return View(viewModel);
        }

        [Route("~/Admin/TrainerCategories/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _dataManager.TrainerCategories.DeleteTrainerCategoryById(id);

            return RedirectToAction("Index");
        }
    }
}
