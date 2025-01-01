using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefitExampleConsoleApp
{
    public interface BlogsRefitApi
    {
        [Get("/api/blog")]
        Task<List<BlogModel>> GetBlogs();
    }
    public class BlogModel
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }   
    }
}
