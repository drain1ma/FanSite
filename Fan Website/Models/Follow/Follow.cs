using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models.Follow
{
    public class Follow
    {
        public int Id { get; set; }
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Following { get; set; }
    }
}
