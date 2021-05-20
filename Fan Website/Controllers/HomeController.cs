using Fan_Website.Models;
using Fan_Website.Models.Forum;
using Fan_Website.Models.Home;
using Fan_Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPost postService; 
        public HomeController(ILogger<HomeController> logger, IPost _postService)
        {
            _logger = logger;
            postService = _postService; 
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel(); 
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = postService.GetLatestPosts(10);
            
            var posts = latestPosts.Select(post => new PostListingModel
            {
                Id = post.PostId, 
                Title = post.Title, 
                AuthorName = post.User.UserName,
                AuthorId = post.User.Id, 
                AuthorRating = post.User.Rating, 
                TotalLikes = post.TotalLikes, 
                DatePosted = post.CreatedOn.ToString(), 
                RepliesCount = post.Replies.Count(),  
                
                Forum = GetForumListingForPost(post)
            });

            return new HomeIndexModel
            {
                LatestPosts = posts, 
                SearchQuery = ""
            }; 
        }

        private ForumListingModel GetForumListingForPost(Post post)
        {
            var forum = post.Forum;

            return new ForumListingModel
            {
                Id = forum.ForumId, 
                Name = forum.PostTitle
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
