using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.ViewModel
{
    public class ForumViewModel
    { 
        public string PostTitle { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }

        public string Slug =>
            PostTitle?.Replace(' ', '-').ToLower();
    }
}
