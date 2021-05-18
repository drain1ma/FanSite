using Fan_Website.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public int Likes { get; set; }
        public bool IsLiked { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
