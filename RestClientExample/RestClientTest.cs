using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientExample
{
    public class RestClientTest
    {
        private readonly RestClient restClient = new RestClient(new Uri("https://localhost:7177"));
        private readonly string _endPoint = "apl/blogs";
        public async Task RunAsync()
        {
            await ReadAsync();
        }
        private async Task ReadAsync()
        {
            RestRequest restRequest = new RestRequest(_endPoint);
            var response = await restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;
                foreach (var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                }
            }
        }
        private async Task EditAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_endPoint}/{id}");
            var response = await restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonstr = response.Content!;
                var item = JsonConvert.DeserializeObject<BlogModel>(jsonstr);
                Console.WriteLine(JsonConvert.SerializeObject(item));
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
            RestRequest restRequest = new RestRequest(_endPoint, Method.Post);
            restRequest.AddJsonBody(blog);
            var response = await restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);

            }
        }
        private async Task DeleteAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_endPoint}/{id}",Method.Delete);
            var response = await restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
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
            RestRequest restRequest = new RestRequest($"{_endPoint}/{id}", Method.Put);
            restRequest.AddJsonBody(blog);
            var response = await restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
    }
}
