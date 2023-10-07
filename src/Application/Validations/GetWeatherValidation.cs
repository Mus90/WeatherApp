using Application.Catalog.Weather.GetByCityName;
using FluentValidation;

namespace Application.Validations
{
    internal class GetWeatherValidation: AbstractValidator<GetWeatherByCityNameRequest>
    {
        public GetWeatherValidation()
        {
            RuleFor(x => x.CityName).NotEmpty().WithMessage("City name is required");
        }
    }
}
