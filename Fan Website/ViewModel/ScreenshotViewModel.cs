using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.ViewModel
{
    public class ScreenshotViewModel
    {
        [Required(ErrorMessage = "Please enter a title.")]
        public String ScreenshotTitle { get; set; }
        [Required(ErrorMessage = "Please upload a screenshot.")]
        public IFormFile Image { get; set; }
        public string ScreenshotDescription { get; set; }
        public string UserName { get; set; }
        public string Slug =>
            ScreenshotTitle?.Replace(' ', '-').ToLower();

        
    }
}
