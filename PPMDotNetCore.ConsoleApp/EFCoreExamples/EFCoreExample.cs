using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using PPMDotNetCore.ConsoleApp.DtoBlogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPMDotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        // protected readonly AddDbContext adb = new AddDbContext();
        private readonly AddDbContext adb;

        public EFCoreExample(AddDbContext adb)
        {
            this.adb = adb;
        }

        public void Run()
        {
            //Read();
            //Edit(2);
            //Edit(23);
            //Create("EFCore", "Pyae", "EFCoreTesting");
            //Update(10, "C# Tuto", "Kai Fuu", "Intro to Dapper");
            Delete(15);
        }



        //Read





        private void Read()
        {

            var lst = adb.Blogs.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("-------------------");
            }
        }




        //Edit





        private void Edit(int id)
        {
            var item = adb.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("-------------------");
        }



        //Create



        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            adb.Blogs.Add(item);
            int result = adb.SaveChanges();
            string message = result > 0 ? "Saving success" : "Saving fail";
            Console.WriteLine(message);
        }




        //Update





        private void Update(int id, string title, string author, string content)
        {
            var item = adb.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data Found");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = adb.SaveChanges();
            string message = result > 0 ? "Updating success" : "Updating fail";
            Console.WriteLine(message);
        }




        //Delete




        private void Delete(int id)
        {
            var item = adb.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data Found");
                return;
            }
            adb.Blogs.Remove(item);
            int result = adb.SaveChanges();
            string message = result > 0 ? "Deleting success" : "Deleting fail";
            Console.WriteLine(message);
        }
    }
}
