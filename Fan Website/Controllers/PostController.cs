using Fan_Website.Models;
using Fan_Website.Services;
using Fan_Website.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Controllers
{
    public class PostController : Controller
    {
        private IPost postService { get; set; }
        public PostController(IPost _postService)
        {
            postService = _postService;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var posts = postService.GetAll();
            return View(posts);
        }



    }
}
