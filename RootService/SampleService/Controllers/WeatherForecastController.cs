using Microsoft.AspNetCore.Mvc;

namespace SampleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private RootServiceReference.RootServiceClient _httpClient;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            IHttpClientFactory httpClientFactory
            )
        {
            _logger = logger;

            _httpClient = new RootServiceReference.RootServiceClient(
                "http://localhost:5075/",
                httpClientFactory.CreateClient("RootServiceClientFirst"));
        }

        [HttpGet(Name = "GetWeatherForecastFirst")]
        public async Task<ActionResult<IEnumerable<RootServiceReference.WeatherForecast>>> GetWeatherForecastFirst()
        {
            _logger.LogInformation("WeatherForecastController GetWeatherForecastFirst called");
            return Ok( await _httpClient.GetWeatherForecastAsync());
        }
    }
}