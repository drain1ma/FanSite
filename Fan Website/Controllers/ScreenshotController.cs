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

namespace Fan_Website.Controllers
{
    public class ScreenshotController: Controller
    {
        private ScreenshotContext context { get; set; }

        private readonly IHostingEnvironment hostingEnvironment;
        
        public ScreenshotController(ScreenshotContext ctx, IHostingEnvironment hostingEnvironment)
        {
            context = ctx;
            this.hostingEnvironment = hostingEnvironment;

        }
        public IActionResult Index()
        {
            var screenshot = context.Screenshots.ToList();
            return View(screenshot);
        }
        public IActionResult Add()
        {
            ViewBag.Action = "Create";
            return View("Edit", new ScreenshotViewModel());
        }
        public IActionResult Create(ScreenshotViewModel model)
        {
            ViewBag.Action = "Add";
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Image != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Screenshot newScreenshot = new Screenshot
                {
                    ScreenshotTitle = model.ScreenshotTitle,
                    ScreenshotDescription = model.ScreenshotDescription,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    ImagePath = uniqueFileName,
                    UserName = User.Identity.Name 
                };

                context.Screenshots.Add(newScreenshot);

                context.SaveChanges();
                return RedirectToAction("Index", "Screenshot");

            }

            return View();
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
