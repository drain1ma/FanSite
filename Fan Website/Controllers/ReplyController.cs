using Fan_Website.Infrastructure;
using Fan_Website.Models;
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
    public class ReplyController : Controller
    {
        private readonly IPost postService;
        private readonly IApplicationUser userService; 
        private readonly UserManager<ApplicationUser> userManager; 
        public ReplyController(IPost _postService, IApplicationUser _userService, UserManager<ApplicationUser> _userManager)
        {
            postService = _postService;
            userService = _userService; 
            userManager = _userManager; 
        }
        public async Task<IActionResult> Create(int id)
        {
            var post = postService.GetById(id);
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var model = new PostReplyModel
            {
                PostContent = post.Content, 
                PostTitle = post.Title, 
                PostId = post.PostId, 
                AuthorId = user.Id,
                AuthorName = User.Identity.Name, 
                AuthorImageUrl = user.ImagePath, 
                AuthorRating = user.Rating,
                Date = DateTime.Now,
                ForumId = post.Forum.ForumId, 
                ForumName = post.Forum.PostTitle
            }; 
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(PostReplyModel model)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.FindByIdAsync(userId);

            var reply = BuildReply(model, user);

            await postService.AddReply((PostReply)reply);
            await userService.UpdateUserRating(userId, typeof(PostReply)); 
            return RedirectToAction("Index", "Post", new { id = model.PostId }); 
        }

        private object BuildReply(PostReplyModel model, ApplicationUser user)
        {
            var post = postService.GetById(model.PostId);

            return new PostReply
            {
                Post = post, 
                Content = model.ReplyContent, 
                CreateOn = DateTime.Now, 
                User = user 
            }; 
        }
    }
}
