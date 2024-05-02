
using Microsoft.EntityFrameworkCore;

public class WeatherService
{
    private readonly WeatherContext _context;

    public WeatherService(WeatherContext ctx)
    {
        _context = ctx;
    }
    public List<WeatherDataResponse> GetWeatherDataResponse()
    {
        var data = (from city in _context.Cities
                    join cityWeather in _context.CityWeather on
                    city.Id equals cityWeather.CityId
                    join weatherData in _context.WeatherData on
                    cityWeather.WeatherStatusId equals weatherData.Id
                    select new { city.Name, weatherData.Status, weatherData.DangerLevel })
                    .Select(row=> new WeatherDataResponse
                    {
                        City = row.Name,
                        DangerLevel = row.DangerLevel,
                        WeatherStatus = row.Status,

                    });

        return data.ToList();
        
    }
}