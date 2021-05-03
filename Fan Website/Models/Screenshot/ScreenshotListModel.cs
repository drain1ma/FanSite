using Fan_Website.Models.Screenshot;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.ViewModel
{
    public class ScreenshotListModel
    {

        public IEnumerable<ScreenshotModel> Screenshot { get; set; }


    }
}
