using Microsoft.AspNetCore.Mvc;

namespace FullStackApp.Server.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherService _myService;

        public WeatherForecastController(WeatherService serv)
        {
            _myService = serv;
        }

        [HttpGet(Name = "GetWeatherData")]
        public IEnumerable<WeatherDataResponse> Get()
        {
            return _myService.GetWeatherDataResponse();
        }
    }
}
