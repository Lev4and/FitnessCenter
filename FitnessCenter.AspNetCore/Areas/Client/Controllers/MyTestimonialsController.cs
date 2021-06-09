using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FitnessCenter.AspNetCore.Areas.Client.Controllers
{
    [Area("Client")]
    public class MyTestimonialsController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly UserManager<IdentityUser> _userManager;

        public MyTestimonialsController(DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            var client = _dataManager.Clients.GetClientByUserId(Guid.Parse(user.Result.Id));

            var viewModel = new MyTestimonialsViewModel()
            {
                Testimonial = _dataManager.Testimonials.GetTestimonialByClientId(client.Id)
            };

            return View(viewModel);
        }

        public IActionResult Save()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            var client = _dataManager.Clients.GetClientByUserId(Guid.Parse(user.Result.Id));

            return View(new Testimonial() { ClientId = client.Id, WrittenAt = DateTime.Now });
        }

        [Route("~/Client/MyTestimonials/Save/{id}")]
        public IActionResult Save(Guid id)
        {
            return View(_dataManager.Testimonials.GetTestimonialById(id));
        }

        [HttpPost]
        public IActionResult Save(Testimonial viewModel)
        {
            if (ModelState.IsValid)
            {
                if (_dataManager.Testimonials.SaveTestimonial(viewModel))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(viewModel);
        }

        [Route("~/Client/MyTestimonials/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Testimonials.DeleteTestimonialById(id);

            return RedirectToAction("Index");
        }
    }
}
