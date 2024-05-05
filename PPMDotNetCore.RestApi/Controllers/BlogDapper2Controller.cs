using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPMDotNetCore.RestApi.Models;
using PPMDotNetCore.Shared;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace PPMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapper2Controller : ControllerBase
    {
        private readonly DapperService _dapperService = new DapperService(ConnectionString.SqlConnectionStringBuilder.ConnectionString);




                                                    // Read





        [HttpGet]
        public IActionResult Read()
        {
            string query = "select * from tbl_blog";
            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //List<BlogsModel> lst = db.Query<BlogsModel>(query).ToList();
            var lst = _dapperService.Query<BlogsModel>(query);
            return Ok(lst);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //string query = "select * from tbl_blog where blogId = @BlogId";
            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query(, new BlogsModel { BlogId = id }).FirstOrDefault();
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            return Ok(item);
        }






                                                    // Create process




        [HttpPost]
        public IActionResult Create(BlogsModel blogs)
        {
            string query = @"INSERT INTO [dbo].[Tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";


            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //int result = db.Execute(query, blogs);
            int result = _dapperService.Execute(query, blogs);   // from dappeService 

            string message = result > 0 ? "Saving success" : "Saving fail";
            return Ok(message);
        }






                                                    // Update







        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogsModel blogs)
        {
            var item = FindById(id);
            if( item is null)
            {
                return NotFound("No data found");
            }
            blogs.BlogId = id;    // update id

            string query = @"UPDATE [dbo].[Tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //int result = db.Execute(query, item);
            int result = _dapperService.Execute(query, blogs);   // from dappeService

            string message = result > 0 ? "Updating success" : "Updating fail";
            return Ok(message);
        }




                                            //Single line update




        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogsModel blogs)
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            string condition = string.Empty;
            if (!string.IsNullOrEmpty(blogs.BlogTitle))
            {
                condition += " [BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blogs.BlogAuthor))
            {
                condition += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blogs.BlogContent))
            {
                condition += " [BlogContent] = @BlogContent, ";
            }
            if(condition.Length == 0)
            {
                return NotFound("No data found");
            }
            condition = condition.Substring(0, condition.Length - 2);
            string query = $@"UPDATE [dbo].[Tbl_blog]
   SET {condition}
 WHERE BlogId = @BlogId";

            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //int result = db.Execute(query, item);
            int result = _dapperService.Execute(query, blogs);   // from dappeService

            string message = result > 0 ? "Updating success" : "Updating fail";
            return Ok(message);
        }





                                                        // Delete






        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {
            var item = FindById(id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            string query = @"DELETE[dbo].[Tbl_blog]WHERE BlogId = @BlogId";

            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //int result = db.Execute(query, new BlogsModel { BlogId = id });
            int result = _dapperService.Execute(query, blogs);   // from dappeService

            string message = result > 0 ? "Deleting success" : "deleting fail";
            return Ok(message);
        }




                                                    // Check id is empty process




        private BlogsModel? FindById(int id)
        {
            string query = "select * from tbl_blog where blogid = @BlogId";
            //using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            //var item = db.Query<BlogsModel>(query, new BlogsModel { BlogId = id }).FirstOrDefault();
            var item = _dapperService.QueryFirstOrDefault<BlogsModel>(query, new BlogsModel { BlogId = id });
            return item;
        }
    }
}
