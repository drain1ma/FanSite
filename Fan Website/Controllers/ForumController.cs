using Fan_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Controllers
{
    public class ForumController: Controller
    {
        private ForumContext context { get; set; }

      

        public ForumController(ForumContext ctx)
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
