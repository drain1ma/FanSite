using Fan_Website.Models.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models.Post
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string PostContent { get; set; }

        public IEnumerable<PostReplyModel> Replies { get; set; }
        public int ForumId { get; set; }
        public string ForumName { get; set; }
    }
}
