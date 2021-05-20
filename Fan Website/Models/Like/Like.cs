using Fan_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website
{
    public class Like
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Post Post { get; set; }
    }
}
