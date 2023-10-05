using Application.Catalog.Weather.GetByCityName;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Mapster;
using Domain.Entities;

namespace Client
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            InitializeMapster();
            var serviceProvider = new ServiceCollection()
            .AddTransient<IWeatherService, WeatherService>()
            .AddTransient<GetWeatherByCityNameHandler>()
            .BuildServiceProvider();

            Console.WriteLine("Please enter city name:");
            var cityName = Console.ReadLine();

            if (cityName == null)
            {
                Console.WriteLine("Invalid city name");
            }
            var weatherHandler = serviceProvider.GetService<GetWeatherByCityNameHandler>();
            var response = await weatherHandler!.Handle(new GetWeatherByCityNameRequest(cityName!));
            var responses = response.Cloudcover;
        }
        static void InitializeMapster()
        {
            TypeAdapterConfig<Weather, GetWeatherByCityNameResponse>
                .NewConfig().Map(dest => dest, src => src.Current);
        }
    }
}