// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//package for => nuget
SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "Pyae02"; //server name
stringBuilder.InitialCatalog = "PPMDotNetCore"; //database name
stringBuilder.UserID = "sa"; //user name
stringBuilder.Password = "sasa@123"; //psassword
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);


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
Console.ReadKey();