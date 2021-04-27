using Fan_Website.Models;
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
        private PostContext context { get; set; }

        public PostController(PostContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult Index()
        {
          
            var posts = context.Posts.ToList();
            ViewBag.Forums = context.Forums.OrderBy(p => p.PostTitle).ToList();
            return View(posts);
        }

        public IActionResult UserPosts()
        {
            var posts = context.Posts.ToList();
            ViewBag.Forums = context.Forums.OrderBy(p => p.PostTitle).ToList();
            return View(posts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Post";
            ViewBag.Forums = context.Forums.OrderBy(p => p.PostTitle).ToList();
            return View("Create", new PostViewModel());
        }
        [HttpPost]
        public IActionResult Create(PostViewModel model)
        {
            ViewBag.Action = "Post";
            ViewBag.Forums = context.Forums.OrderBy(p => p.PostTitle).ToList();
            if (ModelState.IsValid)
            {
                Post newPost = new Post
                {
                    Title = model.Title,
                    Content = model.Content,
                    UserName = User.Identity.Name,
                    CreatedOn = DateTime.UtcNow,
                    Forum = model.Forum,
                    ForumId = model.ForumId                };

                context.Posts.Add(newPost);

                context.SaveChanges();
                return RedirectToAction("Index", "Post");

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
        public IActionResult Delete(Post post)
        {
            context.Posts.Remove(post);
            context.SaveChanges();
            return RedirectToAction("Index", "Post");
        }
    }
}
