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
            var user = userService.GetById(id);

            var model = new ProfileCommentModel
            {
                AuthorId = user.Id,
                AuthorName = User.Identity.Name,
                AuthorImageUrl = user.ImagePath,
                AuthorRating = user.Rating,
                Date = DateTime.Now
            }; 
          
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(ProfileCommentModel model)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.FindByIdAsync(userId);

            var reply = BuildComment(model, user);

            
            await userService.UpdateUserRating(userId, typeof(ProfileComment));
            return RedirectToAction("Detail", "Profile", new { id = model.AuthorId });
        }

        private object BuildComment(ProfileCommentModel model, ApplicationUser user)
        {
            var userProfile = userService.GetById(model.AuthorId);

            return new ProfileComment
            {
                CurrentUser = user,
                Content = model.CommentContent,
                CreateOn = DateTime.Now,
                UserId = userProfile.Id
            };
        }
    }
}
