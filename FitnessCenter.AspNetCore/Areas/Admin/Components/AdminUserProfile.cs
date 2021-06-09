using FitnessCenter.AspNetCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FitnessCenter.AspNetCore.Areas.Admin.Components
{
    public class AdminUserProfile : ViewComponent
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminUserProfile(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            var role = _userManager.GetRolesAsync(user.Result);

            var viewModel = new AdminUserProfileViewModel()
            {
                Name = user.Result.UserName,
                Role = role.Result.First()
            };

            return View("Default", viewModel);
        }
    }
}
