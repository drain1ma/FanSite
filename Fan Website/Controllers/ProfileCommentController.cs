using Fan_Website.Infrastructure;
using Fan_Website.Models.ProfileComment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Controllers
{
    public class ProfileCommentController : Controller
    {
        private readonly IApplicationUser userService;
        private readonly UserManager<ApplicationUser> userManager;
        public ProfileCommentController(IApplicationUser _userService, UserManager<ApplicationUser> _userManager)
        {
            userService = _userService;
            userManager = _userManager; 
        }

        public async Task<IActionResult> Create(string id)
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            var user = userService.GetById(id); 

            var model = new ProfileCommentModel
            {
                AuthorId = currentUser.Id,
                AuthorName = User.Identity.Name,
                AuthorImageUrl = currentUser.ImagePath, 
                AuthorRating = currentUser.Rating,
                Date = DateTime.Now,
                UserId = user.Id,
                OtherUserImagePath = user.ImagePath, 
                OtherUserName = user.UserName, 
                OtherUserRating = user.Rating 
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(ProfileCommentModel model)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.FindByIdAsync(userId);



            var comment = BuildComment(model, user);

            await userService.AddComment((ProfileComment)comment);
            await userService.UpdateUserRating(userId, typeof(ProfileComment));
            return RedirectToAction("Detail", "Profile", new { id = model.UserId });
        }

        private object BuildComment(ProfileCommentModel model, ApplicationUser user)
        {
            var userProfile = userService.GetById(model.UserId);

            return new ProfileComment
            {
                CurrentUser = user,
                Content = model.CommentContent,
                CreateOn = DateTime.Now,
                OtherUser = userProfile
            };
        }
    }
}
