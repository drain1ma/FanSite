using Fan_Website.Infrastructure;
using Fan_Website.Models;
using Fan_Website.Models.Forum;
using Fan_Website.Services;
using Fan_Website.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Controllers
{
    public class ForumController : Controller
    {
        private IForum forumService { get; set; }
        private IPost postService { get; set; }
        private IApplicationUser userService { get; set; }
        private static UserManager<ApplicationUser> userManager;
        public ForumController(IForum _forumService, IPost _postService, IApplicationUser _userService, UserManager<ApplicationUser> _userManager)
        {
            forumService = _forumService;
            postService = _postService;
            userService = _userService;
            userManager = _userManager; 
        }
        public IActionResult Index()
        {
            var forums = forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.ForumId,
                    Name = forum.PostTitle,
                    Description = forum.Description,
                    AuthorId = forum.User.Id, 
                    AuthorName = forum.User.UserName, 
                    AuthorRating = forum.User.Rating.ToString() 
                });

            var model = new ForumIndexModel
            {
                ForumList = forums 
            }; 
            return View(model);
        }

        public IActionResult Topic(int id, string searchQuery)
        {
            var forum = forumService.GetById(id);
            var posts = new List<Post>();

            posts = postService.GetFilteredPosts(forum, searchQuery).ToList(); 
            

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.PostId,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                AuthorName = post.User.UserName, 
                Title = post.Title,
                TotalLikes = post.TotalLikes, 
                DatePosted = post.CreatedOn.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post) 
            });

            var model = new ForumTopicModel
            {
                Posts = postListings,
                Forum = BuildForumListing(forum) 
            }; 

            return View(model); 
        }

        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("Topic", new { id, searchQuery }); 
        }
        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return BuildForumListing(forum); 
        }

        public IActionResult Create()
        {
            var model = new AddForumModel();
            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> AddForum(AddForumModel model)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.FindByIdAsync(userId);
            var forum = new Forum
            {
                PostTitle = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.Now,
                User = user  
            };

            await forumService.Create(forum);
            await userService.UpdateUserRating(userId, typeof(Forum));
            return RedirectToAction("Index", "Forum", new { id = forum.ForumId }); 
        }
        private ForumListingModel BuildForumListing(Forum forum)
        {
            return new ForumListingModel
            {
                Id = forum.ForumId,
                Name = forum.PostTitle,
                Description = forum.Description, 
                AuthorId = forum.User.Id, 
                AuthorName = forum.User.UserName, 
                AuthorRating = forum.User.Rating.ToString() 
            };
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var forum = forumService.GetById(id);
            return View(forum);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Forum forum)
        {
            await forumService.Delete(forum.ForumId);
            return RedirectToAction("Index", "Forum");
        }
    }
}
