using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models
{
    public class Screenshot
    {

        public int ScreenshotId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string ScreenshotTitle { get; set; }
        public string ImagePath { get; set; }
        public string ScreenshotDescription { get; set; }
        public string UserName { get; set; }
        public string Slug =>
            ScreenshotTitle?.Replace(' ', '-').ToLower();
    }
}
