using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models.Screenshot
{
    public class AddScreenshotModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
