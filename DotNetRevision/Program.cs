// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = ".";
stringBuilder.InitialCatalog = "DotNetRevision";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sasa@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
connection.Open();
Console.WriteLine("Connection is open.");

string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adt = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adt.Fill(dt);
connection.Close();
foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["BlogId"]);
    Console.WriteLine("Blog Title" + dr["BlogTitle"]);
    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
    Console.WriteLine("----------------------------");
}
Console.WriteLine("Connection is close.");