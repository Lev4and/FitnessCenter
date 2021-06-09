using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessCenter.AspNetCore.Areas.Client.Controllers
{
    [Area("Client")]
    public class MyServicesController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly UserManager<IdentityUser> _userManager;

        public MyServicesController(DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            var client = _dataManager.Clients.GetClientByUserId(Guid.Parse(user.Result.Id));

            var viewModel = new MyServicesViewModel()
            {
                ClientServices = _dataManager.ClientServices.GetClientServicesByClientId(client.Id).ToList()
            };

            return View(viewModel);
        }
    }
}
