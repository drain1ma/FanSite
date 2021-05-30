using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models.ProfileComment
{
    public class ProfileComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateOn { get; set; }
        public ApplicationUser CurrentUser { get; set; }
        public ApplicationUser OtherUser { get; set; }
    }
}
