using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace PPMDotNetCore.ConsoleApp.AdoDotNetExample
{
    public class AdoDotNetTuto
    {

        //private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        //{
        //    DataSource = "Pyae02",
        //    InitialCatalog = "PPMDotNetCore",
        //    UserID = "sa",
        //    Password = "sasa@123"
        //};

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public AdoDotNetTuto(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
        }

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);


            connection.Open();
            Console.WriteLine("Connection open.");

            string query = "select * from Tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);


            connection.Close();
            Console.WriteLine("Connection close.");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id => " + dr["BlogId"]);
                Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
                Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content => " + dr["BogContent"]);
                Console.WriteLine("--------------------------");
            }
        }
        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);


            connection.Open();
            Console.WriteLine("Connection open.");

            string query = "select * from Tbl_blog where BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);


            connection.Close();
            Console.WriteLine("Connection close.");

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
            DataRow dr = dt.Rows[0];

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine("Blog Id => " + dr["BlogId"]);
                Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
                Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content => " + dr["BogContent"]);
                Console.WriteLine("--------------------------");
            }
        }
        public void Create(string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BogContent", content);
            int result = cmd.ExecuteNonQuery();


            connection.Close();

            string message = result > 0 ? "Saving success" : "Saving fail";
            Console.WriteLine(message);
        }
        public void Update(int id, string title, string author, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"UPDATE [dbo].[Tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BogContent] = @BogContent
 WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BogContent", content);
            int result = cmd.ExecuteNonQuery();


            connection.Close();

            string message = result > 0 ? "Update success" : "Update fail";
            Console.WriteLine(message);
        }
        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"DELETE FROM [dbo].[Tbl_blog]
      WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();


            connection.Close();

            string message = result > 0 ? "Delete success" : "Delete fail";
            Console.WriteLine(message);
        }
    }
}
