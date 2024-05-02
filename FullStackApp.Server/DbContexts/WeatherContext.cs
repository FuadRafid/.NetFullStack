using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
public class WeatherContext : DbContext
{
    public WeatherContext() { }
    public WeatherContext(DbContextOptions<WeatherContext> options)
       : base(options)
    {
    }
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<WeatherData> WeatherData { get; set; }
    public virtual DbSet<CityWeather> CityWeather { get; set; }
}