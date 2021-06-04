using FitnessCenter.AspNetCore.Models;
using FitnessCenter.AspNetCore.Services;
using FitnessCenter.Model.Database;
using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCenter.AspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        private readonly DataManager _dataManager;
        private readonly UploadFileService _uploadFileService;

        public BlogController(IWebHostEnvironment appEnvironment, DataManager dataManager, UploadFileService uploadFileService)
        {
            _appEnvironment = appEnvironment;

            _dataManager = dataManager;
            _uploadFileService = uploadFileService;
        }

        [Route("~/Admin/Blog")]
        [Route("~/Admin/Blog/Index")]
        public IActionResult Index()
        {
            var viewModel = new BlogViewModel()
            {
                Blog = _dataManager.Blog.GetBlog().ToList()
            };

            return View(viewModel);
        }

        public IActionResult Save()
        {
            return View(new Blog() { CreatedAt = DateTime.Now });
        }

        [Route("~/Admin/Blog/Save/{id}")]
        public IActionResult Save(Guid id)
        {
            return View(_dataManager.Blog.GetBlogById(id));
        }

        [HttpPost]
        public IActionResult Save(Blog blog)
        {
            if (ModelState.IsValid)
            {
                if (_dataManager.Blog.SaveBlog(blog))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> UploadCKEditor(IFormFile upload)
        {
            if(await _uploadFileService.UploadFileAsync(upload, "/images/upload/blog/"))
            {
                return new JsonResult(new { uploaded = 1, fileName = upload.FileName, url = $"/images/upload/blog/{upload.FileName}" });
            }

            return new JsonResult(new { uploaded = 0 });
        }

        [HttpGet]
        public IActionResult FileBrowse()
        {
            var viewModel = new BrowseFilesViewModel()
            {
                Files = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _appEnvironment.WebRootPath,
                                    @"images\upload\blog")).GetFiles().ToList()
            };
            return View("FileBrowse", viewModel);
        }

        [Route("~/Admin/Blog/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _dataManager.Blog.DeleteBlogById(id);

            return RedirectToAction("Index");
        }
    }
}
