using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceCategoriesController : Controller
    {
        private readonly DataManager _dataManager;

        public ServiceCategoriesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [Route("~/Admin/ServiceCategories")]
        [Route("~/Admin/ServiceCategories/Index")]
        public IActionResult Index()
        {
            var viewModel = new ServiceCategoriesViewModel()
            {
                ServiceCategories = _dataManager.ServiceCategories.GetServiceCategories().ToList()
            };

            return View(viewModel);
        }

        public IActionResult Save()
        {
            return View(new ServiceCategory());
        }

        [Route("~/Admin/ServiceCategories/Save/{id}")]
        public IActionResult Save(Guid id)
        {
            return View(_dataManager.ServiceCategories.GetServiceCategoryById(id));
        }

        [HttpPost]
        public IActionResult Save(ServiceCategory serviceCategory)
        {
            if (ModelState.IsValid)
            {
                if (_dataManager.ServiceCategories.SaveServiceCategory(serviceCategory))
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Name", "Категория услуг с такими данными уже существует");
            }

            return View(serviceCategory);
        }

        [Route("~/Admin/ServiceCategories/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _dataManager.ServiceCategories.DeleteServiceCategoryById(id);

            return RedirectToAction("Index");
        }
    }
}
