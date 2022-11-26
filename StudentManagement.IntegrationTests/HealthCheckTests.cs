using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace StudentManagement.IntegrationTests
{
    public class HealthCheckTests:IClassFixture<WebApplicationFactory<Program>>
    {
        private WebApplicationFactory<Program> Factory { get; }
        private HttpClient _httpClient { get; set; }

        public HealthCheckTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async Task HealthCheck_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("healthz");
             
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
