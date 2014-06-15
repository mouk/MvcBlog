using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }

        public Comment()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
