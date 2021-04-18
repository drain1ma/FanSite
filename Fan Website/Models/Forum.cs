using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website.Models
{
    public class Forum
    {
        [Key]
        public int ForumId { get; set; }
        public string PostTitle { get; set; }
        public string UserName { get; set; }
        public string Post { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
