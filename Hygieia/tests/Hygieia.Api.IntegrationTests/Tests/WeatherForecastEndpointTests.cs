using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Hygieia.Api.IntegrationTests.Config;
using Hygieia.Api.IntegrationTests.Helpers;
using Hygieia.Application.Models.WeatherForecast;
using NUnit.Framework;

namespace Hygieia.Api.IntegrationTests.Tests;

[TestFixture]
public class WeatherForecastEndpointTests : BaseOneTimeSetup
{
    [Test]
    public async Task Login_Should_Return_User_Information_And_Token()
    {
        // Arrange

        // Act
        var apiResponse = await Client.GetAsync("/api/WeatherForecast");

        // Assert
        var response = await ResponseHelper.GetApiResultAsync<IEnumerable<WeatherForecastResponseModel>>(apiResponse);
        CheckResponse.Succeeded(response);
        response.Result.Should().HaveCount(5);
    }
}
