using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.N_Layer.DataBase;
using WebApplication.N_Layer.Model;

namespace WebApplication.N_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DA_Blog : ControllerBase
    {
        private readonly AppDbContext _db;
        public DA_Blog()
        {
            _db = new AppDbContext();
        }
        public List<BlogModels> GetBlog()
        {
            var lst = _db.Blogs.ToList();
            return lst;
        }
        public BlogModels GetBlogById(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x=>x.BlogId == id);
            return item!;
        }
        public int CreateBlog(BlogModels blog)
        {
            _db.Blogs.Add(blog);
            var item = _db.SaveChanges();
            return item;
        }
        public int UpdateBlogs(int id,BlogModels blog)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;
            blog.BlogId = id;
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _db.SaveChanges();
            return result;
        }
        public int UpdateBlog(int id,BlogModels blog)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;
            blog.BlogId = id;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }
            var result = _db.SaveChanges();
            return result;
        }
        public int DeleteBlog(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;
            _db.Blogs.Remove(item);
            var result = _db.SaveChanges();
            return result;
        }
    }
}
