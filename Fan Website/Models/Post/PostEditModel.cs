using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models.Post
{
    public class PostEditModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ForumName { get; set; }
        public int ForumId { get; set; }
        public DateTime Created { get; set; }
    }
}
