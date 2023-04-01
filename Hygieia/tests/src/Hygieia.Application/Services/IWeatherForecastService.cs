using Hygieia.Application.Models.WeatherForecast;

namespace Hygieia.Application.Services;

public interface IWeatherForecastService
{
    public Task<IEnumerable<WeatherForecastResponseModel>> GetAsync();
}
