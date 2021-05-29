using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models.ProfileComment
{
    public class ProfileCommentModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorImageUrl { get; set; }
        public DateTime Date { get; set; }
        public string CommentContent { get; set; }
        public string UserId { get; set; }
        public string OtherUserImagePath { get; set; }
        public string OtherUserName { get; set; }
        public int OtherUserRating { get; set; }
    }
}
