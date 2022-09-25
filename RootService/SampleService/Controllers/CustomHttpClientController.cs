using Microsoft.AspNetCore.Mvc;
using SampleService.Services;

namespace SampleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomHttpClientController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private IRootServiceClient _rootServiceClient;

        public CustomHttpClientController(
            IRootServiceClient rootServiceClient,
            ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _rootServiceClient = rootServiceClient;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<RootServiceReference.WeatherForecast>>> Get()
        {
            return Ok(await _rootServiceClient.Get());
        }
    }
}
