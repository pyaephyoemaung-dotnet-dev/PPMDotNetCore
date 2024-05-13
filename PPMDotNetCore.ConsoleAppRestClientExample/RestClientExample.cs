using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PPMDotNetCore.ConsoleAppRestClientExample
{
    public class RestClientExample
    {
        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7177"));
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
            //RestRequest restRequest = new RestRequest(_blogEndPoint, Method.Get);
            //var response = await _client.GetAsync(restRequest);

            RestRequest restRequest = new RestRequest(_blogEndPoint);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
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
            RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}");
            var response = await _client.GetAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }



        //Delete process





        private async Task DeleteAsync(int id)
        {

            RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}");
            var response = await _client.GetAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
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
            RestRequest restRequest = new RestRequest(_blogEndPoint, Method.Post);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
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
            RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Put);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }



        //Single Line Update process



        private async Task PatchAsync(int id, string title, string author, string content)
        {
            BlogModel blogDto = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            RestRequest restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Patch);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
    }
}
