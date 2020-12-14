using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ExampleApp.Shared;

namespace ExampleApp.Client.Data
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenHelper tokenHelper;

        public WeatherForecastService(HttpClient httpClient, ITokenHelper tokenHelper)
        {
            _httpClient = httpClient;
            this.tokenHelper = tokenHelper;
        }
        
        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            var token = await tokenHelper.GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            return await _httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}