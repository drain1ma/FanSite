using Fan_Website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IApplicationUser userService;
        private readonly IUpload uploadService; 

        public ProfileController(UserManager<ApplicationUser> _userManager, IApplicationUser _userService, IUpload _uploadService)
        {
            userManager = _userManager;
            userService = _userService;
            uploadService = _uploadService; 
        }
        public IActionResult Detail(string id)
        {
            return View();
        }
    }
}
