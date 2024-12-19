using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerTesting.Model;

namespace NLayerTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterfaceBlog : ControllerBase
    {
        private readonly BS_Blog _bsBlog;
        public InterfaceBlog()
        {
            _bsBlog = new BS_Blog();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _bsBlog.GetBlog();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogByid(int id)
        {
            var lst = _bsBlog.GetBlogById(id);
            if (lst is null)
            {
                return NotFound("No Data found.");
            }
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModels blog)
        {
            var lst = _bsBlog.CreateBlog(blog);
            string message = lst > 0 ? "Saving succeful." : "Saving fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlogs(int id, BlogModels blog)
        {
            var item = _bsBlog.GetBlogById(id);
            if (item is null)
            {
                return NotFound("No data Found.");
            }
            var result = _bsBlog.UpdateBlogs(id, blog);
            string message = result > 0 ? "Updating succeful" : "Updating fail";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateBlog(int id, BlogModels blog)
        {
            var lst = _bsBlog.GetBlogById(id);
            if (lst is null)
            {
                return NotFound("No data found.");
            }
            var result = _bsBlog.UpdateBlog(id, blog);
            string message = result > 0 ? "Updating succeful" : "Updating fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var lst = _bsBlog.GetBlogById(id);
            if (lst is null)
            {
                return NotFound("No data found.");
            }
            var item = _bsBlog.DeleteBlog(id);
            string message = item > 0 ? "Deleting succeful" : "Deleting fail";
            return Ok(message);
        }
    }
}
