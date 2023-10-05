using Application.Catalog.Weather.GetByCityName;
using Domain.Entities;
using Mapster;

namespace Application.Mapper;

public class MappingConfig : TypeAdapterConfig
{
    public MappingConfig()
    {
        TypeAdapterConfig<Weather, GetWeatherByCityNameResponse>.NewConfig();
    }
}