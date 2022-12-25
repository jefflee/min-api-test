using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Test
{
    /// <summary>
    /// Refer to :
    /// https://blog.darkthread.net/blog/testing-min-api/
    /// https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0
    /// </summary>
    [TestFixture]
    public class IntegrationTests
    {
        private WebApplicationFactory<Program> _app;

        [SetUp]
        public void Setup()
        {
            _app = new WebApplicationFactory<Program>();
        }

        [Test]
        public async Task GetWeatherForecast_Get5WeatherForecast()
        {
            HttpClient client = _app.CreateClient();
            var resp = await client.GetFromJsonAsync<List<WeatherForecast>>("/WeatherForecast");
            resp.Should().HaveCount(5);
        }
    }
}