using Fan_Website.Models.Follow;
using Fan_Website.Models.ProfileComment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website
{
    public class ProfileModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserRating { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime MemberSince { get; set; }
        public IFormFile ImageUpload { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public List<Follow> Follows { get; set; }
        public List<Follow> Followings { get; set; }
        public IEnumerable<ProfileCommentModel> ProfileComments { get; set; }
        public string Bio { get; set; }
    }

}
