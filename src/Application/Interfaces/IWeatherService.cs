using Domain.Entities;

namespace Infrastructure.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeather(string cityName);
    }
}