using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
                if (_dataManager.Users.SaveUser(viewModel.Client, _dataManager.Roles.GetRoleByName("Клиент"), viewModel.CurrentPassword, viewModel.NewPassword))
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(nameof(viewModel.Client.Email), "Пользователь с таким email уже существует");
                ModelState.AddModelError(nameof(viewModel.Client.UserName), "Пользователь с таким логином уже существует");
            }

            return View(viewModel);
        }
    }
}
