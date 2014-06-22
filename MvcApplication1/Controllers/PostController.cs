using System.Linq;
using System.Web.Mvc;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly PostContext _dataContext = new PostContext();

        public ActionResult Index()
        {
            var posts = _dataContext.Posts.Take(9)
                              .Select(p => new
                                  {
                                      Id = p.Id,
                                      Title = p.Title,
                                      Body = p.Body.Substring(0, 200) + " ...</p>",
                                      Tags = p.Tags.Select(t => t.Name),
                                      CommentCount = p.Comments.Count()
                                  }).AsEnumerable()
                              .Select(p => new PostViewModel
                                  {
                                      Id = p.Id,
                                      Title = p.Title,
                                      Body = p.Body,
                                      CommentCount = p.CommentCount,
                                      Tags = p.Tags.ToList()
                                  }).ToList();
            var model = new PostListingViewModel
                {
                    Posts = posts,
                    TotalCount = _dataContext.Posts.Count()
                };
            return View(model);
        }

        public ActionResult Show(int id)
        {
            var post = _dataContext.Posts.SingleOrDefault(p => p.Id == id);
            if(post == null)
                return HttpNotFound();

            return View(post);

        }
        public ActionResult Tagged(string id)
        {
            var posts = _dataContext.PostsByTagName(id).ToList();

            return Json(posts, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddComment(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
