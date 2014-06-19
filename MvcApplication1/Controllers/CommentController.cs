using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using MyBlog.Data;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class CommentController : Controller
    {
        private readonly PostContext _dataContext = new PostContext();
        [HttpPost]
        public ActionResult Add(CommentInsertModel insertModel)
        {


            //.............
            var comment = new Comment
                {

                };


            _dataContext.Insert(insertModel.PostId, comment);
            
            return Json(new {Id = comment.Id});
        }

    }
}
