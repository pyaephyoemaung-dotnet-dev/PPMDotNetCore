using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefitExampleConsoleApp
{
    public class RefitExample
    {
        private readonly BlogsRefitApi _service = RestService.For<BlogsRefitApi>("https://localhost:7177");
        public async Task RunAsync()
        {
            await ReadBlogsAsync();
        }
        private async Task ReadBlogsAsync()
        {
            var lst = await _service.GetBlogs();
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("----------------");
            }
        }
    }
}
