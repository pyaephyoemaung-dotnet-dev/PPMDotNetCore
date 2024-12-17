using ASP.NetCore.RestApiTest.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace ASP.NetCore.RestApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperBlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Saving succeful." : "Saving fail.";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id,BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            blog.BlogId = id;
            string query = @"UPDATE [dbo].[tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Updating succeful." : "Updating fail.";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,BlogModel blog)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found.");
            }
            string condition = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                condition += " [BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                condition += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                condition += "[BlogContent] = @BlogContent, ";
            }
            if (condition.Length == 0)
            {
                return NotFound("No data to Update.");
            }
            condition = condition.Substring(0, condition.Length - 2);
            blog.BlogId = id;
            string query = $@"UPDATE [dbo].[tbl_blog]
   SET {condition}
 WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            string message = result > 0 ? "Updating succeful." : "Updating fail.";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            string query = @"DELETE FROM [dbo].[tbl_blog]
      WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query,item);
            string message = result > 0 ? "Deleting succeful." : "Deleting fail.";
            return Ok(message);
        }
        private BlogModel? FindById(int id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
            return item;
        }
    }
}
