﻿using Fan_Website.Infrastructure;
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
        private  IPost postService { get; set; }
        private  IForum forumService { get; set; }
        private  IApplicationUser userService { get; set; }
        private AppDbContext context; 
        private static UserManager<ApplicationUser> userManager; 

        public PostController(IPost _postService, IForum _forumService, IApplicationUser _userService, UserManager<ApplicationUser> _userManager, AppDbContext ctx)
        {
            postService = _postService;
            forumService = _forumService;
            userService = _userService; 
            userManager = _userManager;
            context = ctx; 
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

        [HttpGet]
        public IActionResult UserPosts()
        {
            var posts = postService.GetAll().Select(post => new PostListingModel
            {
                Id = post.PostId, 
                Title = post.Title, 
                AuthorId = post.User.Id, 
                AuthorName = post.User.UserName, 
                AuthorRating = post.User.Rating, 
                DatePosted = post.CreatedOn.ToString(),  
                ForumId = post.Forum.ForumId, 
                ForumName = post.Forum.PostTitle, 
                RepliesCount = post.Replies.Count() 
            }); 

            return View(posts);
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
            await userService.UpdateUserRating(userId, typeof(Post)); 
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
                AuthorImageUrl = reply.User.ImagePath, 
                AuthorName = reply.User.UserName, 
                AuthorId = reply.User.Id, 
                AuthorRating = reply.User.Rating, 
                Date = reply.CreateOn, 
                ReplyContent = reply.Content
            }); 
        }
        public IActionResult Delete(int id)
        {
            var post = postService.GetById(id);
            var model = new DeletePostModel
            {
                PostId = post.PostId,
                PostAuthor = post.User.UserName,
                PostContent = post.Content
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var post = postService.GetById(id);
            postService.Delete(id); 
            return RedirectToAction("Index", "Forum", new { id = post.Forum.ForumId });
        }
    }
}
