using Fan_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Controllers
{
    public class PostController : Controller
    {
        private PostContext context { get; set; }

        public PostController(PostContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var posts = context.Posts.ToList(); 
            return View(posts);
        }
    }
}
