
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.RefitExample
{
    public class RefitExample
    {
         IBlogsApi _services = RestService.For<IBlogsApi>("https://localhost:7158"); 
        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(1);
            //await EditAsync(7);
            //await DeleteAsync(1);
            // await DeleteAsync(7);
            await UpdateAsync(8,"Pyae", "JKJK", "KHKJ");
        }
        private async Task ReadAsync()
        {
            var lst = await _services.GetBlogs();
            foreach (var item in lst)
            {
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("-----------------------------");
            }
        }
        private async Task EditAsync(int id)
        {
            try
            {
                var item = await _services.EditBlog(id);
                if (item is null)
                {
                    Console.WriteLine("No data found.");
                }
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("-----------------------------");
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private async Task DeleteAsync(int id)
        {
            try
            {
                var item = await _services.DeleteBlog(id);
                if (item is null)
                {
                    Console.WriteLine("No data found.");
                }
                Console.WriteLine(item);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
            }
        }
        private async Task CreateAsync(string title,string author,string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                var message = await _services.CreateBlog(blog);
                Console.WriteLine(message);
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.StatusCode.ToString());
            }
        }
        private async Task UpdateAsync(int id,string title,string author,string content)
        {
            try
            {
                BlogModel blog = new BlogModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };
                var message = await _services.UpdateBlog(id, blog);
                Console.WriteLine(message);
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
            }
        }
    }
}
