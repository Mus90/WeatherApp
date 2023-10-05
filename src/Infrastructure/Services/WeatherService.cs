using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private const string AccessToken = "5ac458f2a3ae298400cf3562923db38b";
        private const string BaseUrl = "http://api.weatherstack.com";

        public WeatherService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<Weather> GetWeather(string cityName)
        {
            try
            {
                var requestUrl = $"/current?access_key={AccessToken}&query={cityName}";
                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var weather = JsonConvert.DeserializeObject<Weather>(responseContent);
                return weather!;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request error: {ex.Message}");
                throw;
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

}
