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
        public String ScreenshotTitle { get; set; }
        public string ImagePath { get; set; }
        public String ScreenshotDescription { get; set; }
        public String UserName { get; set; }
        public string Slug =>
            ScreenshotTitle?.Replace(' ', '-').ToLower();
    }
}
