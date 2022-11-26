using Microsoft.AspNetCore.Mvc.Testing;
using StudentManagement.API;
using System.Text.Json;
using System.Net.Http.Json;

namespace StudentManagement.IntegrationTests.Controllers
{
    public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private HttpClient _httpClient { get; set; }
        public WeatherForecastControllerTests(WebApplicationFactory<Program> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("http://localhost/WeatherForecast");

            _httpClient = factory.CreateClient(); // CreateClient method can
            // handle redirects
        }

        [Fact]
        public async Task GetWeatherForecast_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("");

            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task GetWeatherForecast_ReturnsValues()
        {
            var responseStream = await _httpClient.GetStreamAsync("");

            var response = await JsonSerializer
                                 .DeserializeAsync<IEnumerable<WeatherForecast>>
                                 (responseStream, new JsonSerializerOptions
                                 {
                                     PropertyNameCaseInsensitive = true,
                                 });

            Assert.True(response.Any());

        }


        [Fact]
        public async Task GetWeatherForecast_ReturnsValuesDeserialized()
        {
            // this extension method allows us to get the deserialized object
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("");

            Assert.True(response.Any());

        }
    }
}
