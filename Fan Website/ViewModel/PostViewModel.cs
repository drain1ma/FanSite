using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.ViewModel
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UserName { get; set; }
        public string Forum { get; set; }
        public string Slug =>
            Title?.Replace(' ', '-').ToLower();
    }
}
