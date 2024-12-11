// See https://aka.ms/new-console-template for more information
using DotNetRevision;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

AdoDotNetSample adoDotNetSample = new AdoDotNetSample();
//adoDotNetSample.Read();
//adoDotNetSample.Create("About DontNetNet", "Pyae Phyoe Maung", "Nothing");
//adoDotNetSample.Update(12, "Test Title", "Test Author", "Test Content");
//adoDotNetSample.Delete(12);
adoDotNetSample.Edit(2);