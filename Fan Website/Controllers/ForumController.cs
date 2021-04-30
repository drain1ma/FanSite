using Fan_Website.Models;
using Fan_Website.Models.Forum;
using Fan_Website.Services;
using Fan_Website.ViewModel;
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


        public ForumController(IForum _forumService, IPost _postService)
        {
            forumService = _forumService;
            postService = _postService; 
        }
        public IActionResult Index()
        {
            var forums = forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.ForumId,
                    Name = forum.PostTitle,
                    Description = forum.Description 

                });

            var model = new ForumIndexModel
            {
                ForumList = forums 
            }; 
            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = forumService.GetById(id);
            var posts = forum.Posts;

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.PostId,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Title = post.Title,
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

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return BuildForumListing(forum); 
        }

        private ForumListingModel BuildForumListing(Forum forum)
        {
            return new ForumListingModel
            {
                Id = forum.ForumId,
                Name = forum.PostTitle,
                Description = forum.Description
            };
        }
    }
}
