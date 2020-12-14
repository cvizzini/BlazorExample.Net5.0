using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ExampleApp.Tester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var client = new HttpClient();
            var token = await TokenHelper.GetAccessTokenAsync();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.Token}");
            var authorizedResponse = await client.GetAsync("http://localhost:5000/WeatherForecast");

            var resultString = await authorizedResponse.Content.ReadAsStringAsync();

            Console.WriteLine(resultString);     
        }
    }
}
