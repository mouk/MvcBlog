using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class CommentInsertModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Body { get; set; }
    }
}