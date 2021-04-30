using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website
{
    public class Forum
    {
        public string ForumId { get; set; }
        [Required(ErrorMessage = "Please enter a title.")] 
        public string PostTitle { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public string Slug =>
            PostTitle?.Replace(' ', '-').ToLower();
    }
}
