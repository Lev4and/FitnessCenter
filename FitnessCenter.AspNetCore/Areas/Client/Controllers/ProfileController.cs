using FitnessCenter.AspNetCore.Services;
using FitnessCenter.Model.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FitnessCenter.AspNetCore.Areas.Client.Controllers
{
    [Area("Client")]
    public class ProfileController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly UploadFileService _uploadFileService;
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(DataManager dataManager, UploadFileService uploadFileService, UserManager<IdentityUser> userManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
            _uploadFileService = uploadFileService;
        }

        public IActionResult Save()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            var client = _dataManager.Clients.GetClientByUserId(Guid.Parse(user.Result.Id));

            return View(client);
        }

        [HttpPost]
        public IActionResult Save(FitnessCenter.Model.Database.Entities.Client viewModel, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if(uploadedFile != null)
                {
                    if(_uploadFileService.UploadFileAsync(uploadedFile, $"/images/upload/clients/{viewModel.Id}").Result)
                    {
                        viewModel.Photo = $"images/upload/clients/{viewModel.Id}/{uploadedFile.FileName}";
                    }
                }

                if (_dataManager.Clients.SaveClient(viewModel))
                {
                    return Redirect("~/Client/Home/Index");
                }
            }

            return View(viewModel);
        }
    }
}
