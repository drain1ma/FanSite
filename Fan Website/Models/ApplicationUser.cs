using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website
{
    public class ApplicationUser: IdentityUser
    {
        public int Rating { get; set; }
        public string ImagePath { get; set; }
        public DateTime MemberSince { get; set; }
        public bool IsActive { get; set; }

    }
}
