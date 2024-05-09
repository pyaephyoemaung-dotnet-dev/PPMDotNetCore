using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPMDotNetCore.RestApiWithNLayer.Models;

namespace PPMDotNetCore.RestApiWithNLayer.Feature.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly Basic_logic _basic_Logic;
        public BlogController()
        {
            _basic_Logic = new Basic_logic();
        }
        



                                                //Read Process




        [HttpGet]
        public IActionResult Read()
        {
            var lst = _basic_Logic.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _basic_Logic.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }






                                                    //Created process





        [HttpPost]
        public IActionResult Create(BlogsModel blogs)
        {
            var result = _basic_Logic.CreateBlog(blogs);
            string message = result > 0 ? "Saving success" : "Saving fail";
            return Ok(message);
        }






                                                       //Update process







        [HttpPut("{id}")]
        public IActionResult Update(int id ,BlogsModel blog)
        {
            var item = _basic_Logic.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            var result = _basic_Logic.UpdateBlog(id, blog);
            string message = result > 0 ? "Updating success" : "Updating fail";
            return Ok(message);
        }





                                                        //Single Update process






        [HttpPatch]
        public IActionResult Patch(int id, BlogsModel blog)
        {
            var item = _basic_Logic.GetBlog(id);
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
            var result = _basic_Logic.UpdateBlog(id, blog);
            string message = result > 0 ? "Updating success" : "Updating fail";
            return Ok(message);
        }








                                                        //Delete process







        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _basic_Logic.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            var result = _basic_Logic.DeleteBlog(id);
            string message = result > 0 ? "Deleting success" : "Deleting fail";
            return Ok(message);
        }
    }
}
