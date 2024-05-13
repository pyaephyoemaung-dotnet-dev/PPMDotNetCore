using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PPMDotNetCore.ConsoleAppHttpClientExample
{
    public class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7177") };
        private readonly string _blogEndPoint = "api/blogs";
        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(1);
            //await EditAsync(100);
            //await DeleteAsync();
            //await CreateAsync("Title", "Pyae", "Dev");
            //await UpdateAsync(5, "Kai", "Kaifuu", "Dev");
            await PatchAsync(5, "Kaifuu", "KaiFuu", "Kaifuu");
        }



                                                //Read process


        


        private async Task ReadAsync()
        {
            var response = await _client.GetAsync(_blogEndPoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                foreach (var blog in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(blog));
                    Console.WriteLine(blog.BlogTitle);
                    Console.WriteLine(blog.BlogAuthor);
                    Console.WriteLine(blog.BlogContent);
                }
            }
            else
            {
                Console.WriteLine("No Data Found");
            }
        }
        


                                                //Edit process





        private async Task EditAsync(int id)
        {
            var response = await _client.GetAsync($"{_blogEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        


                                                //Delete process





        private async Task DeleteAsync(int id)
        {
            var response = await _client.GetAsync(_blogEndPoint);
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
        


                                                //Create process





        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blogDto = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string blogJson = JsonConvert.SerializeObject(blogDto);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync(_blogEndPoint, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
        


                                                //Update process





        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel blogDto = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string blogJson = JsonConvert.SerializeObject(blogDto);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync($"{_blogEndPoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }



                                                    //Single Line Update process



        private async Task PatchAsync(int id ,string title, string author, string content)
        {
            BlogModel blogDto = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string blogJson = JsonConvert.SerializeObject(blogDto);
            HttpContent httpContent = new StringContent(blogJson, Encoding.UTF8, Application.Json);
            var response = await _client.PatchAsync($"{_blogEndPoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }
    }
}
