using Fan_Website.Infrastructure;
using Fan_Website.Models;
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
        public ProfileController(UserManager<ApplicationUser> _userManager, IApplicationUser _userService, IUpload _uploadService, IConfiguration _configuration)
        {
            userManager = _userManager;
            userService = _userService;
            uploadService = _uploadService;
            configuration = _configuration; 
        }
        public IActionResult Detail(string id)
        {
            var user = userService.GetById(id);

            var model = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                UesrRating = user.Rating.ToString(),
                ProfileImageUrl = user.ImagePath,
                MemberSince = user.MemberSince
            }; 
            return View(model);
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
