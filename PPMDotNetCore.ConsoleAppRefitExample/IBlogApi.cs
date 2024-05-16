using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMDotNetCore.ConsoleAppRefitExample
{
    public interface IBlogApi
    {
        [Get("/api/blog")]
        Task<List<BlogModel>> GetBlog();
        [Get("/api/blog/{id}")]
        Task<BlogModel> EditBlog(int id);
        [Post("/api/blog")]
        Task<string> CreateAsync(BlogModel blogModel);
        [Put("/api/blog/{id}")]
        Task<string> UpdateAsync(int id,BlogModel blogModel);
        [Delete("/api/blog/{id}")]
        Task<string> DeleteAsync(int id);
        [Patch("/api/blog/{id}")]
        Task<string> PatchAsync(int id, string title, string author, string content);
    }
    public class BlogModel
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
}
