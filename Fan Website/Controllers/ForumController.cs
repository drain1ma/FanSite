using Fan_Website.Models;
using Fan_Website.ViewModel;
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
        [HttpGet] 
        public IActionResult Create()
        {
            ViewBag.Action = "Post"; 
            return View("Create", new ForumViewModel()); 
        }
        [HttpPost]
        public IActionResult Create(ForumViewModel model)
        {
            ViewBag.Action = "Post";
            if (ModelState.IsValid)
            {


                Forum newPost = new Forum
                {
                    PostTitle = model.PostTitle,
                    Post = model.Post,
                    UserName = User.Identity.Name,
                    CreatedOn = DateTime.Now 
                };

                context.Posts.Add(newPost);

                context.SaveChanges();
                return RedirectToAction("Index", "Forum");

            }

            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var post = context.Posts.Find(id);
            return View(post);
        }

        [HttpPost]
        public IActionResult Delete(Forum posts)
        {
            context.Posts.Remove(posts);
            context.SaveChanges();
            return RedirectToAction("Index", "Forum");
        }
    }
}
