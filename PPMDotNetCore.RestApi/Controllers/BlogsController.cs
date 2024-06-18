using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PPMDotNetCore.RestApi.Db;
using PPMDotNetCore.RestApi.Models;

namespace PPMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        //private readonly AddDbContext _adb;

        //public BlogsController()
        //{
        //    _adb = new AddDbContext();
        //}


        private readonly AddDbContext _adb;

        public BlogsController(AddDbContext adb)
        {
            _adb = adb;
        }




        //Read Process




        [HttpGet]
        public IActionResult Read()
        {
            var lst = _adb.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _adb.Blogs.FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }






                                                    //Created process





        [HttpPost]
        public IActionResult Create(BlogsModel blogs)
        {
            _adb.Blogs.Add(blogs);
            var result = _adb.SaveChanges();
            string message = result > 0 ? "Saving success" : "Saving fail";
            return Ok(message);
        }






                                                       //Update process







        [HttpPut("{id}")]
        public IActionResult Update(int id ,BlogsModel blog)
        {
            var item = _adb.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _adb.SaveChanges();
            string message = result > 0 ? "Updating success" : "Updating fail";
            return Ok(message);
        }





                                                        //Single Update process






        [HttpPatch]
        public IActionResult Patch(int id, BlogsModel blog)
        {
            var item = _adb.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
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
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _adb.SaveChanges();
            string message = result > 0 ? "Updating success" : "Updating fail";
            return Ok(message);
        }








                                                        //Delete process







        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _adb.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            _adb.Blogs.Remove(item);
            var result = _adb.SaveChanges();
            string message = result > 0 ? "Deleting success" : "Deleting fail";
            return Ok(message);
        }
    }
}
