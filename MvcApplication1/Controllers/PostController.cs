using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        private PostContext _posts = new PostContext();

        public ActionResult Index()
        {
            var model = new PostListingViewModel
                {
                    Posts = _posts.Posts.Take(9)
                    .Select(p => new PostViewModel
                        {
                            Id = p.Id,
                            Title = p.Title,
                            Body =  p.Body.Substring(0,200) + " ...",
                            Tags =  p.Tags.Select(t => t.Name).ToList(),
                            CommentCount = p.Comments.Count()
                        })
                        .ToList(),
                        TotalCount = _posts.Posts.Count()
                };
            return View(model);
        }

    }
}
