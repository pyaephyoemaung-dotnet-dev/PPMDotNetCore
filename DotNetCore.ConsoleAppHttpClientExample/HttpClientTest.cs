using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetCore.ConsoleAppHttpClientExample
{
    public class HttpClientTest
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7177") };
        private readonly string _endPoint = "api/blogs";
        public async Task RunAsync()
        {
            //await GetBlog();
            //await EditAsync(22);
            //await EditAsync(100);
            //await DeleteAsync(22);
            //await CreateAsync("P", "p", "p");
            await UpdateAsync(23,"Pp", "pm", "pm");
        }
        private async Task GetBlog()
        {
            var response = await _client.GetAsync(_endPoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                foreach (var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }

        private async Task EditAsync(int id)
        {
            var response = await _client.GetAsync($"{_endPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonstr = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<BlogModel>(jsonstr)!;
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Blog Title => {item.BlogTitle}");
                Console.WriteLine($"Blog Author => {item.BlogAuthor}");
                Console.WriteLine($"Blog Content => {item.BlogContent}");
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_endPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task CreateAsync(string title,string author,string content)
        {
            BlogModel blog = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string blogStr = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(blogStr,Encoding.UTF8,Application.Json);
            var response = await _client.PostAsync(_endPoint, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task UpdateAsync(int id,string title,string author,string content)
        {
            BlogModel blog = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string blotstr = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(blotstr, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_endPoint}/{id}",httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}
