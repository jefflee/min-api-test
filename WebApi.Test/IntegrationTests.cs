using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace WebApi.Test
{
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