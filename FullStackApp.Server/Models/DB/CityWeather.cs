using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(CityId), nameof(WeatherStatusId))]

public class CityWeather
{
    public virtual int CityId { get; set; }
    public virtual int WeatherStatusId { get; set; }
}