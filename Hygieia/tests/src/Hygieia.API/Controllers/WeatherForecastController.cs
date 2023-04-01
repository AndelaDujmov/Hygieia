using Hygieia.Application.Models;
using Hygieia.Application.Models.WeatherForecast;
using Hygieia.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Hygieia.API.Controllers;

[Authorize]
public class WeatherForecastController : ApiController
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(
            ApiResult<IEnumerable<WeatherForecastResponseModel>>.Success(await _weatherForecastService.GetAsync()));
    }
}
