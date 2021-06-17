using FitnessCenter.AspNetCore.Models;
using FitnessCenter.AspNetCore.Services;
using FitnessCenter.Model.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FitnessCenter.AspNetCore.Areas.Client.Controllers
{
    [Area("Client")]
    public class AccountController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
        }

        public IActionResult Save()
        {
            var viewModel = new ClientViewModel()
            {
                Client = _userManager.FindByNameAsync(User.Identity.Name).Result,
                CurrentPassword = "",
                NewPassword = ""
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Save(ClientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!Regex.IsMatch(viewModel.CurrentPassword, PasswordValidateConfig.Pattern))
                {
                    ModelState.AddModelError("CurrentPassword", "Пароль не соответствует формату");
                }

                if (!string.IsNullOrEmpty(viewModel.Client.PasswordHash))
                {
                    if (!Regex.IsMatch(viewModel.NewPassword, PasswordValidateConfig.Pattern))
                    {
                        ModelState.AddModelError("NewPassword", "Пароль не соответствует формату");
                    }
                }

                if (ModelState.ErrorCount == 0)
                {
                    if (_dataManager.Users.SaveUser(viewModel.Client, _dataManager.Roles.GetRoleByName("Клиент"), viewModel.CurrentPassword, viewModel.NewPassword))
                    {
                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError(nameof(viewModel.Client.Email), "Пользователь с таким email уже существует");
                    ModelState.AddModelError(nameof(viewModel.Client.UserName), "Пользователь с таким логином уже существует");
                }
            }

            return View(viewModel);
        }
    }
}
