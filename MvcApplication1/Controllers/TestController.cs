using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using MyBlog.Data;

namespace MyBlog.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            var c = new PostContext().Posts.Take(2).ToList();
            return Json(c, JsonRequestBehavior.AllowGet);
        }

    }
}
