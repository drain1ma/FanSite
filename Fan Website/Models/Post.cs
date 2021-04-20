using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter content.")]
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }
        public string Forum { get; set; }
        public string Slug =>
            Title?.Replace(' ', '-').ToLower();

    }
}
