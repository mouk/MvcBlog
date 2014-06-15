using Data;
using NLipsum.Core;

namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.PostContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.PostContext context)
        {
            foreach (var post in context.Posts)
            {
                context.Posts.Remove(post);
            }
            foreach (var tag in context.Tags)
            {
                context.Tags.Remove(tag);
            }
            
            var i = new NLipsum
                .Core
                .LipsumGenerator();
            var tags = 
                i.GenerateSentences(1, Sentence.Long).SelectMany(s => s.Split(' '))
                .Select(t => new Tag{Name = t})
                .Take(5).ToList();
            tags.AddRange(tags.ToArray());

            Random rand = new Random();
            
            for (int j = 0; j < 10; j++)
            {
                var post = new Post
                    {
                        Body = i.GenerateParagraphs(3, Paragraph.Medium).Select(p => "<p>" + p + "</p>").Aggregate((a,b) => a + b),
                        Title = i.GenerateSentences(1).Single(),
                        Tags = tags.Skip(rand.Next(5)).Take(3).ToList(),
                        CreatedAt = DateTime.Now.AddDays(rand.Next(600)),
                        Comments = i
                        .GenerateSentences(1 + rand.Next(6))
                        .Select(t => new Comment
                            {
                                Title = t,
                                Username = i.GenerateWords(1).Single(),
                                Body = i.GenerateLipsum(1)
                            })
                        .ToList()

                    };
                context.Posts.AddOrUpdate(p => p.Title,post);
            }

           

        }
    }
}
