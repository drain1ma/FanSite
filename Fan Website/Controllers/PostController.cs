using Fan_Website.Models;
using Fan_Website.Models.Post;
using Fan_Website.Models.Reply;
using Fan_Website.Services;
using Microsoft.AspNetCore.Identity;
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
        private IForum forumService { get; set; }
        private static UserManager<ApplicationUser> userManager; 

        public PostController(IPost _postService, IForum _forumService, UserManager<ApplicationUser> _userManager)
        {
            postService = _postService;
            forumService = _forumService;
            userManager = _userManager; 
        }
        [HttpGet]
        public IActionResult Index(int id)
        {

            var post = postService.GetById(id);
            var replies = BuildPostReplies(post.Replies); 
            var model = new PostIndexModel
            {
                Id = post.PostId,
                Title = post.Title, 
                AuthorName = post.User.UserName, 
                AuthorId = post.User.Id, 
                AuthorRating = post.User.Rating, 
                AuthorImageUrl = post.User.ImagePath, 
                Date = post.CreatedOn, 
                PostContent = post.Content, 
                Replies = replies,
                ForumId = post.Forum.ForumId, 
                ForumName = post.Forum.PostTitle 

            }; 
            return View(model);
        }

        public IActionResult Create(int id)
        {
            var forum = forumService.GetById(id);

            var model = new NewPostModel
            {
                ForumName = forum.PostTitle, 
                ForumId = forum.ForumId, 
                AuthorName = User.Identity.Name 
            };

            return View(model); 
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.FindByIdAsync(userId); 
            var post = BuildPost(model, user);

            await postService.Add(post);

            return RedirectToAction("Index", "Post", new {id = post.PostId}); 
        }

        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var forum = forumService.GetById(model.ForumId); 

            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                CreatedOn = DateTime.Now,
                User = user,
                Forum = forum
            }; 
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel
            {
                Id = reply.Id, 
                AuthorName = reply.User.Id, 
                AuthorId = reply.User.Id, 
                AuthorRating = reply.User.Rating, 
                Date = reply.CreateOn, 
                ReplyContent = reply.Content
            }); 
        }
    }
}
