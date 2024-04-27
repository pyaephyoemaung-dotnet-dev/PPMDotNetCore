using Dapper;
using PPMDotNetCore.ConsoleApp.DtoBlogs;
using PPMDotNetCore.ConsoleApp.Services;
using System.Data;
using System.Data.SqlClient;

namespace PPMDotNetCore.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {
        public void Run()
        {
            //Read();
            //Edit(1);
            // Edit(21);
            //Create("C# Testing", "Kai Fuu", "Intro to Dapper");
            //Update(20,"C# Tuto", "Kai Fuu", "Intro to Dapper");
            Delete(21);
        }


        //                                                      Read


        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog").ToList();

            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("-------------------");
            }
        }




        //                                                       Edit




        private void Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query("select * from tbl_blog where blogid = @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("-------------------");
        }




        //                                                         Create




        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            string query = @"INSERT INTO [dbo].[Tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";


            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Saving success" : "Saving fail";
            Console.WriteLine(message);
        }




        //                                                          Update




        private void Update(int id, string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            string query = @"UPDATE [dbo].[Tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Updating success" : "Updating fail";
            Console.WriteLine(message);
        }




        //                                                          Deleting





        private void Delete(int id)
        {
            var item = new BlogDto
            {
                BlogId = id,
            };
            string query = @"DELETE[dbo].[Tbl_blog]WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Deleting success" : "deleting fail";
            Console.WriteLine(message);
        }
    }
}
