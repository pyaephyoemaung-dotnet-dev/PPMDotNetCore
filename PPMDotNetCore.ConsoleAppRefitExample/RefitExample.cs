using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PPMDotNetCore.ConsoleAppRefitExample
{
    public class RefitExample
    {
        private readonly IBlogApi services = RestService.For<IBlogApi>("https://localhost:7158");
        public async Task RunAsync()
        {
            //await GetTaskAsync();
            await EditAsync(1);
            await EditAsync(100);
        }
        private async Task GetTaskAsync()
        {
            var lst = await services.GetBlog();
            foreach (var blog in lst)
            {

                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
                Console.WriteLine("---------------------");
            }
        }
        private async Task EditAsync(int id)
        {
            try
            {
                var item = await services.EditBlog(id);
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);  
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("---------------------");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var message = await services.CreateAsync(blogModel);
            Console.WriteLine(message);
        }
        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var message = await services.UpdateAsync(id, blogModel);
            Console.WriteLine(message);
        }
        private async Task PatchAsync(int id, string title, string author, string content)
        {
            var item = new BlogModel();
            if(item is null)
            {
                Console.WriteLine("No data Found");
            }
            if (!string.IsNullOrEmpty(item.BlogTitle))
            {
                item.BlogTitle = title;
            }
            if (!string.IsNullOrEmpty(item.BlogAuthor))
            {
                item.BlogAuthor = author;
            }
            if (!string.IsNullOrEmpty(item.BlogContent))
            {
                item.BlogContent = content;
            }
            var message = await services.PatchAsync(id,title,author,content);
            Console.WriteLine(message);
        }
        private async Task DeleteAsync(int id)
        {
            var message = await services.DeleteAsync(id);
            Console.WriteLine(message);
        }
    }
}
