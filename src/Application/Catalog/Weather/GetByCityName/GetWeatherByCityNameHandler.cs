using Application.Interfaces;
using Application.Validations;
using FluentValidation.Results;
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
        var validator = new GetWeatherValidation();
        ValidationResult result = validator.Validate(request);

        if (!result.IsValid)
        {
            throw new ApplicationException(string.Join("\n", result.Errors));
        }

        var response = await _weatherService.GetWeather(request.CityName);
        if (response.Current == null)
        {
            throw new Exception($"Cant find weather info for {request.CityName}");
        }
        return response.Adapt<GetWeatherByCityNameResponse>();
    }
}
