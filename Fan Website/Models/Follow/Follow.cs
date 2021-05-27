using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models.Follow
{
    public class Follow
    {
        public int Id { get; set; }
        public string Follower { get; set; }
        public string Following { get; set; }
    }
}
