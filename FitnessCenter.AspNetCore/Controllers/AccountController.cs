using FitnessCenter.AspNetCore.Models;
using FitnessCenter.AspNetCore.Services;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCenter.AspNetCore.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly UploadFileService _uploadFileService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(DataManager dataManager, UploadFileService uploadFileService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _uploadFileService = uploadFileService;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        public IActionResult Register()
        {
            var viewModel = new RegisterViewModel()
            {
                Client = new Client() { DateOfBirth = DateTime.Now },
                Genders = _dataManager.Genders.GetGenders().ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel, IFormFile uploadedFile)
        {
            if(!_dataManager.Users.ContainsUserByEmail(viewModel.Email) && !_dataManager.Users.ContainsUserByEmail(viewModel.Login))
            {
                var user = new IdentityUser()
                {
                    Email = viewModel.Email,
                    UserName = viewModel.Login,
                    PhoneNumber = viewModel.Phone
                };

                if(_dataManager.Users.SaveUser(user, _dataManager.Roles.GetRoleByName("Клиент"), viewModel.Password, ""))
                {
                    viewModel.Client.UserId = Guid.Parse(user.Id);

                    if (_dataManager.Clients.SaveClient(viewModel.Client))
                    {
                        if (uploadedFile != null)
                        {
                            if (_uploadFileService.UploadFileAsync(uploadedFile, $"images/upload/clients/{viewModel.Client.Id}").Result)
                            {
                                viewModel.Client.Photo = $"images/upload/clients/{viewModel.Client.Id}/{uploadedFile.FileName}";
                            }
                        }

                        _dataManager.Clients.SaveClient(viewModel.Client);

                        return RedirectToAction("Login");
                    }
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userEmail = await _userManager.FindByEmailAsync(model.EmailOrLogin);
                var userName = await _userManager.FindByNameAsync(model.EmailOrLogin);

                if (userEmail != null || userName != null)
                {
                    var user = userEmail != null ? userEmail : userName;

                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(LoginViewModel.Password), "Неверный пароль");
                    }
                }
                else
                {
                    if(userEmail == null && userName == null)
                    {
                        ModelState.AddModelError(nameof(LoginViewModel.EmailOrLogin), "Введен неверный адрес электронной почты или логин");
                    }
                    else
                    {
                        if (userEmail == null)
                        {
                            ModelState.AddModelError(nameof(LoginViewModel.EmailOrLogin), "Введен неверный адрес электронной почты");
                        }
                        else
                        {
                            ModelState.AddModelError(nameof(LoginViewModel.EmailOrLogin), "Введен неверный логин");
                        }
                    }
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
