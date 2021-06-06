using Fan_Website.Infrastructure;
using Fan_Website.Models;
using Fan_Website.Models.Follow;
using Fan_Website.Models.Profile;
using Fan_Website.Models.ProfileComment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Fan_Website.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager; 
        private readonly IApplicationUser userService;
        private readonly IUpload uploadService;
        private readonly IConfiguration configuration;
        private readonly AppDbContext context; 
        public ProfileController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, IApplicationUser _userService, IUpload _uploadService, IConfiguration _configuration, AppDbContext ctx)
        {
            userManager = _userManager;
            signInManager = _signInManager; 
            userService = _userService;
            uploadService = _uploadService;
            configuration = _configuration;
            context = ctx; 
        }
        public IActionResult Detail(string id)
        {
            var user = userService.GetById(id);
            var comments = BuildProfileComments(user.ProfileComments); 
            var model = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                ProfileImageUrl = user.ImagePath,
                MemberSince = user.MemberSince,
                Following = user.Following,
                Followers = user.Followers,
                Follows = user.Follows,
                Followings = user.Followings, 
                ProfileComments = comments,
                Bio = user.Bio 
            }; 
            return View(model);
        }

        private IEnumerable<ProfileCommentModel> BuildProfileComments(IEnumerable<ProfileComment> comments)
        {
            return comments.Select(comment => new ProfileCommentModel
            {
                Id = comment.Id,
                AuthorImageUrl = comment.CurrentUser.ImagePath,
                AuthorName = comment.CurrentUser.UserName,
                AuthorId = comment.CurrentUser.Id,
                AuthorRating = comment.CurrentUser.Rating,
                Date = comment.CreateOn,
                CommentContent = comment.Content,
                OtherUserImagePath = comment.OtherUser.ImagePath,
                OtherUserName = comment.OtherUser.UserName,
                OtherUserRating = comment.OtherUser.Rating,
                UserId = comment.OtherUser.Id
            });
        }
        [HttpPost]
        public int UpdateFollows(string id)
        {
            var user = userService.GetById(id);
            var userId = userManager.GetUserId(User);
            var currentUser = userService.GetById(userId);
            var follows = user.Follows; 
           
            var follow = new Follow
            {
                Following = user,
                Follower = currentUser
            };
           
            if (follows.Any())
            {
                var userFollow = follows.Where(follow => follow.Follower == currentUser).Where(follow => follow.Following == user).FirstOrDefault();
                if (userFollow != null)
                {
                    context.Remove(userFollow);
                    context.SaveChanges();
                    user.Followers -= 1;
                    context.Users.Update(user);
                    context.SaveChanges();
                    currentUser.Following -= 1;
                    context.Users.Update(currentUser);
                    context.SaveChanges();
                    return user.Followers;
                    
                }
                else if (userFollow == null)
                {
                    context.Add(follow);
                    context.SaveChanges();
                    user.Follows.Add(follow);
                    context.Users.Update(user);
                    context.SaveChanges();
                    user.Followers += 1;
                    context.Users.Update(user);
                    context.SaveChanges();
                    currentUser.Following += 1;
                    context.Users.Update(currentUser);
                    context.SaveChanges();
                    currentUser.Followings.Add(follow);
                    context.Users.Update(currentUser);
                    context.SaveChanges();
                    return user.Followers;
                }
                context.Remove(follow);
                context.SaveChanges();
                user.Followers -= 1;
                context.Users.Update(user);
                context.SaveChanges();
                currentUser.Following -= 1;
                context.Users.Update(currentUser);
                context.SaveChanges();
                return user.Followers;
            }

            if (!follows.Any())
            {
                context.Add(follow);
                context.SaveChanges();
                user.Follows.Add(follow);
                context.Users.Update(user);
                context.SaveChanges();
                user.Followers += 1;
                context.Users.Update(user);
                context.SaveChanges();
                currentUser.Following += 1;
                context.Users.Update(currentUser);
                context.SaveChanges();
                currentUser.Followings.Add(follow);
                context.Users.Update(currentUser);
                context.SaveChanges();
                return user.Followers;
            }


            return 0; 
        }

        public IActionResult Followers(string id)
        {
            var user = userService.GetById(id);
            var comments = BuildProfileComments(user.ProfileComments);
            var model = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                ProfileImageUrl = user.ImagePath,
                MemberSince = user.MemberSince,
                Following = user.Following,
                Followers = user.Followers,
                Follows = user.Follows,
                Followings = user.Followings, 
                ProfileComments = comments
            };
            return View(model);
        }
        public IActionResult Following(string id)
        {
            var user = userService.GetById(id);
            var comments = BuildProfileComments(user.ProfileComments);
            var model = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                ProfileImageUrl = user.ImagePath,
                MemberSince = user.MemberSince,
                Following = user.Following,
                Followers = user.Followers,
                Follows = user.Follows,
                Followings = user.Followings, 
                ProfileComments = comments
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult EditBio(string id)
        {
            var user = userService.GetById(id);

            var model = new ProfileEditModel
            {
                UserId = user.Id, 
                UserName = user.UserName, 
                ProfileImageUrl = user.ImagePath, 
                Bio = user.Bio 
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBio(ProfileEditModel user)
        {
            await userService.EditProfile(user.UserId, user.Bio, user.UserName);
            return RedirectToAction("Detail", "Profile", new { id = user.UserId });
        }
        [HttpGet]
        public IActionResult EditUserName(string id)
        {
            var user = userService.GetById(id);

            var model = new ProfileEditModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                ProfileImageUrl = user.ImagePath,
                Bio = user.Bio
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUsername(ProfileEditModel user)
        {
            await userService.EditProfile(user.UserId, user.Bio, user.UserName);
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> UploadProfileImage(IFormFile file)
        {
            var userId = userManager.GetUserId(User);
            var connectionString = configuration.GetConnectionString("AzureStorageAccount");
            var container = uploadService.GetBlobContainer(connectionString, "profile-images");

            var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var filename = Path.Combine(parsedContentDisposition.FileName.Trim('"'));

            var blockBlob = container.GetBlockBlobReference(filename);

            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            await userService.SetProfileImage(userId, blockBlob.Uri);

            return RedirectToAction("Detail", "Profile", new { id = userId });
        } 
    }
}
