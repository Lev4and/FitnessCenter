using FitnessCenter.AspNetCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FitnessCenter.AspNetCore.Areas.Manager.Components
{
    public class ManagerUserProfile : ViewComponent
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ManagerUserProfile(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            var role = _userManager.GetRolesAsync(user.Result);

            var viewModel = new ManagerUserProfileViewModel()
            {
                Name = user.Result.UserName,
                Role = role.Result.First()
            };

            return View("Default", viewModel);
        }
    }
}
