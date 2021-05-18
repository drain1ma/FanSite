using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fan_Website
{
    public class EditReplyModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateOn { get; set; }
        public Post Post { get; set; }
    }
}
