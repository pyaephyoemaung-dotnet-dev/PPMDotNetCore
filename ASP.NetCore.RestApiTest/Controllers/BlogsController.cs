using ASP.NetCore.RestApiTest.Database;
using ASP.NetCore.RestApiTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCore.RestApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BlogsController()
        {
            _db = new AppDbContext();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var lst = _db.Blogs.ToList();
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data Found.");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving succeful." : "Saving fail.";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,BlogModel blog)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating succeful." : "Updating fail.";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,BlogModel blog)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            if (!string.IsNullOrEmpty(item.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(item.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(item.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating succeful." : "Updating fail.";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting succeful." : "Deleting fail.";
            return Ok(message);
        }
    }
}
