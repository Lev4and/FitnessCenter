using FitnessCenter.AspNetCore.Models;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FitnessCenter.AspNetCore.Controllers
{
    public class BlogController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogController(DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var viewModel = new BlogViewModel()
            {
                Blog = _dataManager.Blog.GetBlog().ToList()
            };

            return View(viewModel);
        }

        [Route("~/Blog/Details/{id}")]
        public IActionResult Details(Guid id)
        {
            var viewModel = new BlogDetailsViewModel()
            {
                Blog = _dataManager.Blog.GetBlogById(id),
                CommentId = null,
                Message = ""
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SendMessage(BlogDetailsViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.Message))
            {
                var userTask = _userManager.FindByNameAsync(User.Identity.Name);
                var user = userTask.Result;

                var roleTask = _userManager.GetRolesAsync(user);
                var role = roleTask.Result;

                var client = _dataManager.Clients.GetClientByUserId(Guid.Parse(user.Id));

                if (viewModel.CommentId != null)
                {
                    var answer = new BlogCommentAnswer()
                    {
                        ClientId = client.Id,
                        CommentId = viewModel.CommentId,
                        Message = viewModel.Message,
                        WrittenAt = DateTime.Now
                    };

                    _dataManager.BlogCommentAnswers.SaveBlogCommentAnswer(answer);
                }
                else
                {
                    var comment = new BlogComment()
                    {
                        ClientId = client.Id,
                        BlogId = viewModel.Blog.Id,
                        Message = viewModel.Message,
                        WrittenAt = DateTime.Now
                    };

                    _dataManager.BlogComments.SaveBlogComment(comment);
                }
            }

            return Redirect($"~/Blog/Details/{viewModel.Blog.Id}");
        }
    }
}
