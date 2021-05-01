using Fan_Website.Models;
using Fan_Website.Models.Forum;
using Fan_Website.Models.Search;
using Fan_Website.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Controllers
{
    public class SearchController : Controller
    {
        private IPost postService { get; set; }
        public SearchController(IPost _postService)
        {
            postService = _postService; 
        }
        public IActionResult Results(string searchQuery)
        {
            var posts = postService.GetFilteredPosts(searchQuery).ToList();
            var areNoResults = (!string.IsNullOrEmpty(searchQuery) && !posts.Any()); 

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.PostId,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorRating = post.User.Rating,
                DatePosted = post.CreatedOn.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)

            });

            var model = new SearchResultModel
            {
                Posts = postListings, 
                SearchQuery = searchQuery, 
                EmptySearchResults = areNoResults 
            }; 
            return View(model);
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return new ForumListingModel
            {
                Id = forum.ForumId, 
                Name = forum.PostTitle, 
                Description = forum.Description 
            }; 
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            return RedirectToAction("Results", new { searchQuery }); 
        }
    }
}
