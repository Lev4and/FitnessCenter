using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCenter.AspNetCore.Areas.Client.Components
{
    public class ClientUserProfile : ViewComponent
    {
        private readonly DataManager _dataManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ClientUserProfile(DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var userTask = _userManager.FindByNameAsync(User.Identity.Name);
            var user = userTask.Result;

            var roleTask = _userManager.GetRolesAsync(user);
            var role = roleTask.Result;

            var client = _dataManager.Clients.GetClientByUserId(Guid.Parse(user.Id));

            var viewModel = new ClientUserProfileViewModel()
            {
                Name = user.UserName,
                Role = role.First(),
                Photo = client.Photo
            };

            return View("Default", viewModel);
        }
    }
}
