using Fan_Website.Infrastructure;
using Fan_Website.Models;
using Fan_Website.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext context { get; set; }
        private readonly IUnitOfWork unitOfWork; 
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            this.unitOfWork = unitOfWork; 
        }
        [HttpGet]
        public IActionResult AccountInfo()
        {
            var users = userManager.Users; 
            return View(users); 
        }

        [HttpPost]
        public IActionResult AccountInfo(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UploadImage(file); 
            }
            return View();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null) {
                    return RedirectToAction("Login"); 
                }

                var result = await userManager.ChangePasswordAsync(user,
                    model.Password, model.NewPassword);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description); 
                    }
                    return View(); 
                }
                await signInManager.RefreshSignInAsync(user);
                return View("Confirmation"); 
            }

            return View(model); 
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(IFormFile file, RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    unitOfWork.UploadImage(file);
                    // Copy data from RegisterViewModel to IdentityUser
                    var otheruser = new ApplicationUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        ImagePath = file.FileName
                    };
                    var otherresult = await userManager.CreateAsync(otheruser, model.Password);


                   
                    // If user is successfully created, sign-in the user using
                    // SignInManager and redirect to index action of HomeController
                    if (otherresult.Succeeded)
                    {
                        await signInManager.SignInAsync(otheruser, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }


                }

                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                var result = await userManager.CreateAsync(user, model.Password);



                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                // Store user data in AspNetUsers database table


                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
       

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
    }
}
