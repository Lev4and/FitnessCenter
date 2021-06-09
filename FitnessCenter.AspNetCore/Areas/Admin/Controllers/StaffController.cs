using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffController : Controller
    {
        private readonly DataManager _dataManager;

        public StaffController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var viewModel = new StaffViewModel()
            {
                Managers = _dataManager.Users.GetManagers().ToList()
            };

            return View(viewModel);
        }

        public IActionResult Save()
        {
            var viewModel = new ManagerViewModel()
            {
                Manager = new IdentityUser(),
                CurrentPassword = "",
                NewPassword = ""
            };

            return View(viewModel);
        }

        [Route("~/Admin/Staff/Save/{id}")]
        public IActionResult Save(Guid id)
        {
            var viewModel = new ManagerViewModel()
            {
                Manager = _dataManager.Users.GetUserById(id),
                CurrentPassword = "",
                NewPassword = ""
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(ManagerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if(_dataManager.Users.SaveUser(viewModel.Manager, _dataManager.Roles.GetRoleByName("Менеджер"), viewModel.CurrentPassword, viewModel.NewPassword))
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(nameof(viewModel.Manager.Email), "Пользователь с таким email уже существует");
                ModelState.AddModelError(nameof(viewModel.Manager.UserName), "Пользователь с таким логином уже существует");
            }

            return View(viewModel);
        }

        [Route("~/Admin/Staff/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Users.DeleteManagerById(id);

            return RedirectToAction("Index");
        }
    }
}
