using Fan_Website.Infrastructure;
using Fan_Website.Models;
using Fan_Website.Models.Follow;
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
        private readonly IApplicationUser userService;
        private readonly IUpload uploadService;
        private readonly IConfiguration configuration;
        private readonly AppDbContext context; 
        public ProfileController(UserManager<ApplicationUser> _userManager, IApplicationUser _userService, IUpload _uploadService, IConfiguration _configuration, AppDbContext ctx)
        {
            userManager = _userManager;
            userService = _userService;
            uploadService = _uploadService;
            configuration = _configuration;
            context = ctx; 
        }
        public IActionResult Detail(string id)
        {
            var user = userService.GetById(id);

            var model = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                ProfileImageUrl = user.ImagePath,
                MemberSince = user.MemberSince,
                Following = user.Following,
                Followers = user.Followers,
                Follows = user.Follows 
            }; 
            return View(model);
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
                Following = user.Id,
                Follower = currentUser.Id 
            };
           
            if (follows.Any())
            {
                var userFollow = follows.Where(follow => follow.Follower == currentUser.Id).Where(follow => follow.Following == user.Id).FirstOrDefault();
                if (userFollow != null)
                {
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
                else if (userFollow == null)
                {
                    context.Add(follow);
                    context.SaveChanges();
                    user.Followers += 1;
                    context.Users.Update(user);
                    context.SaveChanges();
                    currentUser.Following += 1;
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
                user.Followers += 1;
                context.Users.Update(user);
                context.SaveChanges();
                currentUser.Following += 1;
                context.Users.Update(currentUser);
                context.SaveChanges();
                return user.Followers;
            }


            return 0; 
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
