using System.Collections.Generic;

namespace MyBlog.Models
{
    public class PostListingViewModel
    {
        public IList<PostViewModel> Posts { get; set; }
        public int TotalCount { get; set; }
    }
}