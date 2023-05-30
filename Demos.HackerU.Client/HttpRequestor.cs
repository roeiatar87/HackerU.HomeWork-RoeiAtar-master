using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demos.HackerU.Client
{
    public class HttpRequestor
    {
        readonly HttpClient client;
        public HttpRequestor()
        {
            //01 Create HyypClient instance with base Address
            client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }
        public async Task<string> GetItemServerDataAsync(string collectionName, int id)
        {
            string? jsonResponse = string.Empty;
            try
            {
                //02 Get Server Resource Data
                using HttpResponseMessage response = await client.GetAsync(collectionName + "/" + id);
                // 03 Ensure that the operation is return as 200
                response.EnsureSuccessStatusCode();

                // 03 Get the string content 
                jsonResponse = await response.Content.ReadAsStringAsync();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return jsonResponse;
        }

        public async Task PostItemToServerAsync(object data)
        {

            try
            {
                //Convert data to json
                string newObject = JsonSerializer.Serialize(data);
                //Put in envelop stringcontent
                using StringContent jsonContent = new StringContent(newObject, Encoding.UTF8, "application/json");
                using HttpResponseMessage response = await client.PostAsync("todos", jsonContent);

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"{jsonResponse}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
