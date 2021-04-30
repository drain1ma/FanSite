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
        private AppDbContext context { get; set; }

      

        public ForumController(AppDbContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var forums = context.Forums.ToList();
            return View(forums);
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
                var posts = context.Posts.ToList(); 
                Forum newForum = new Forum
                {

                    PostTitle = model.PostTitle,
                    Description = model.Description,
                    UserName = User.Identity.Name,
                    CreatedOn = DateTime.UtcNow,
                    ForumId = model.PostTitle,
                    Posts = posts     
                };

                context.Forums.Add(newForum);

                context.SaveChanges();
                return RedirectToAction("Index", "Forum");

            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var forum = context.Forums.Find(id);
            return View(forum);
        }

        [HttpPost]
        public IActionResult Delete(Forum forum)
        {
            context.Forums.Remove(forum);
            context.SaveChanges();
            return RedirectToAction("Index", "Forum");
        }
    }
}
