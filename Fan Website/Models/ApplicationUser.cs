using Fan_Website.Models.Follow;
using Fan_Website.Models.ProfileComment;
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
        public int Following { get; set; }
        public int Followers { get; set; }
        public List<Follow> Follows { get; set; }
        public List<Follow> Followings { get; set; }
        public IEnumerable<ProfileComment> ProfileComments { get; set; }
        public string Bio { get; set; }
       

    }
}
