using Fan_Website.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fan_Website.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Fan_Website.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using Fan_Website.Models.Screenshot;

namespace Fan_Website.Controllers
{
    public class ScreenshotController: Controller
    {
        private AppDbContext context { get; set; }

        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IApplicationUser userService;
        private readonly IConfiguration configuration;
        private readonly IUpload uploadService;
        private readonly IScreenshot screenshotService; 
        private readonly UserManager<ApplicationUser> userManager; 
        public ScreenshotController(AppDbContext ctx, IHostingEnvironment hostingEnvironment, IApplicationUser _userService, 
            IConfiguration _configuration, IUpload _uploadService, IScreenshot _screenshotService, UserManager<ApplicationUser> _userManager)
        {
            context = ctx;
            this.hostingEnvironment = hostingEnvironment;
            userService = _userService;
            configuration = _configuration;
            uploadService = _uploadService;
            screenshotService = _screenshotService;
            userManager = _userManager; 
        }
        public IActionResult Index(int id)
        {
            var screenshot = screenshotService.GetById(id);

            var model = new ScreenshotListModel()
            {
                
            };
            return View(model);
        }
        public IActionResult UserScreenshots()
        {
            var screenshot = context.Screenshots.ToList();
            return View(screenshot); 
        }

        public async Task<IActionResult> AddScreenshot(NewScreenshotModel model)
        {
            var userId = userManager.GetUserId(User);
            var user = await userManager.FindByIdAsync(userId);
            var screenshot = BuildScreenshot(model, user);

            
            return RedirectToAction("Index", "Screenshot", new { id = screenshot.ScreenshotId }); 
        }

        private Screenshot BuildScreenshot(NewScreenshotModel model, ApplicationUser user)
        {
            return new Screenshot
            {
                ScreenshotId = model.Id, 
                ScreenshotTitle = model.Title, 
                ScreenshotDescription = model.Content, 
                ImagePath = model.ScreenshotImageUrl, 
                CreatedOn = DateTime.Now, 
                User = user
            }; 
        }

        public async Task<IActionResult> UploadScreenshotImage(IFormFile file, int id)
        {
            var screenshot = screenshotService.GetById(id);
            var screenshotId = screenshot.ScreenshotId; 
            var connectionString = configuration.GetConnectionString("AzureStorageAccount");
            var container = uploadService.GetBlobContainer(connectionString);

            var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var filename = Path.Combine(parsedContentDisposition.FileName.Trim('"'));

            var blockBlob = container.GetBlockBlobReference(filename);

            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            await screenshotService.SetScreenshotImage(screenshotId, blockBlob.Uri);

            return RedirectToAction("Index", "Screenshot", new { id = screenshotId });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var screenshot = context.Screenshots.Find(id);
            return View(screenshot);
        }

        [HttpPost]
        public IActionResult Delete(Screenshot screenshot)
        {
            context.Screenshots.Remove(screenshot);
            context.SaveChanges();
            return RedirectToAction("Index", "Screenshot");
        }
    }
}
