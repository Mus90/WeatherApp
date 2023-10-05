using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Infrastructure.Services;
using Mapster;

namespace Application.Catalog.Weather.GetByCityName;

public class GetWeatherByCityNameRequest
{
    public string CityName { get; set; }
    public GetWeatherByCityNameRequest(string cityName)
    {
        CityName = cityName;
    }
}

public class GetWeatherByCityNameHandler : IApplicationHandler<GetWeatherByCityNameRequest, GetWeatherByCityNameResponse>
{
    private readonly IWeatherService _weatherService;

    public GetWeatherByCityNameHandler(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<GetWeatherByCityNameResponse> Handle(GetWeatherByCityNameRequest request)
    {
        var response = await _weatherService.GetWeather(request.CityName);
        return response.Adapt<GetWeatherByCityNameResponse>();
    }
}
