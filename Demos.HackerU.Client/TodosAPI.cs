using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demos.HackerU.Client
{
    public class TodosAPI
    {
        readonly HttpClient client;
        public TodosAPI()
        {
            //01 Create HyypClient instance with base Address
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7011");
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

        public async Task PostItemToServerAsync(string data)
        {

            try
            {
                string newObject = JsonSerializer.Serialize(data);
                using StringContent dataContent = new StringContent(newObject, Encoding.UTF8, @"application/json");
                using HttpResponseMessage response = await client.PostAsync("api/todos", dataContent);
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

