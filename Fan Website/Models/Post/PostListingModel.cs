using Fan_Website.Models.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models
{
    public class PostListingModel
    {
        public ForumListingModel Forum { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }
        public int TotalLikes { get; set; }
        public int ForumId { get; set; }
        public string ForumName { get; set; }

        public int RepliesCount { get; set; }
    }
}
