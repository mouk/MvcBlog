using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        private PostContext _posts = new PostContext();

        public ActionResult Index()
        {
            return View();
        }

    }
}
