using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FitnessCenter.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Администратор"))
                {
                    return Redirect("~/Admin/Home/Index");
                }

                if (User.IsInRole("Менеджер"))
                {
                    return Redirect("~/Manager/Home/Index");
                }
            }

            var viewModel = new MainViewModel()
            {
                Testimonials = _dataManager.Testimonials.GetTestimonials().ToList(),
                Services = _dataManager.Services.GetServices().ToList(),
                Trainers = _dataManager.Trainers.GetTrainers().ToList(),
                Blog = _dataManager.Blog.GetBlog(4, 1).ToList()
            };

            return View(viewModel);
        }
    }
}
