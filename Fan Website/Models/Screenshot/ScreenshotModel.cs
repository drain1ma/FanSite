using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models.Screenshot
{
    public class ScreenshotModel
    {
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorRating { get; set; }
        public string ScreenshotImageUrl { get; set; }
        public int ScreenshotId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string DatePosted { get; set; }
        public IFormFile ScreenshotUpload { get; set; }
    }
}
