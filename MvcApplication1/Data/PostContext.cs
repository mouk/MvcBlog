using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Data;

namespace MyBlog.Data
{
    public class PostContext : DbContext
    {
        public PostContext() : base("DefaultConnection")
        {
            
        }
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public IQueryable<Post> PostsByTagName(string tagName)
        {
            //var tag = Tags.Single(t => t.Name == tagName);
            return Posts
                .Where(p => p.Tags.Any(t => t.Name==  tagName));
        }
        public int Insert(int postId, Comment comment)
        {
            var post = Posts.Single(p => p.Id == postId);
            post.Comments.Add(comment);
            SaveChanges();
            return comment.Id;
        }
        public int InsertOrUpdate(Post post)
        {
            if (post.Id == 0)
                Posts.Add(post);
            else
            {
                Posts.Attach(post);
                Entry(post).State = EntityState.Modified;
            }
            SaveChanges();
            return post.Id;
        }
    }
}
