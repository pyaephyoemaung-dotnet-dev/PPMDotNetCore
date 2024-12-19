using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.N_Layer.Model;

namespace WebApplication.N_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BS_Blog : ControllerBase
    {
        private readonly DA_Blog _daBlog;
        public BS_Blog()
        {
            _daBlog = new DA_Blog();
        }

        public List<BlogModels> GetBlog()
        {
            var lst = _daBlog.GetBlog();
            return lst;
        }

        public BlogModels GetBlogById(int id)
        {
            var item = _daBlog.GetBlogById(id);
            return item;
        }

        public int CreateBlog(BlogModels blog)
        {
            var item = _daBlog.CreateBlog(blog);
            return item;
        }

        public int UpdateBlogs(int id,BlogModels blog)
        {
            var item = _daBlog.UpdateBlogs(id,blog);
            return item;
        }

        public int UpdateBlog(int id,BlogModels blog)
        {
            var item = _daBlog.UpdateBlog(id, blog);
            return item;
        }

        public int DeleteBlog(int id)
        {
            var item = _daBlog.DeleteBlog(id);
            return item;
        }
    }
}
