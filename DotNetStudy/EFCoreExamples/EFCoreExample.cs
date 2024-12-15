using DotNetStudy.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetStudy.EFCoreExamples
{
    internal class EFCoreExample
    {
        private readonly AppDbContext _db = new AppDbContext();
        public void Run()
        {
            //Read();
            //Update(1,".net", "Pyae", ".net");
            //Edit(1);
            Delete(14);
        }
        private void Read()
        {
            var lst = _db.Blogs.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("--------------");
            }
        }
        private void Create (string title, string author,string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            _db.Blogs.Add(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving succeful." : "Saving Fail.";
            Console.WriteLine(message);
        }
        private void Edit(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data Found.");
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("--------------");
        }
        private void Update(int id, string title,string author, string content)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data Found");
            }
            item.BlogId = id;
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating succeful" : "Updating failo";
            Console.WriteLine(message);
        }
        private void Delete(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data found");
            }
            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting succeful" : "Deleting fail";
            Console.WriteLine(message);
        }
    }
}
