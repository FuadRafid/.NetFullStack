using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Tests
{
    [TestClass()]
    public class WeatherServiceTests
    {
        [TestMethod()]
        public void WeatherServiceTest()
        {
            var cityData = new List<City>
            {
                new City { Id=1, Name = "BBB", Country = "BD", Code = 1 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<City>>();
            mockSet.As<IQueryable<City>>().Setup(m => m.Provider).Returns(cityData.Provider);
            mockSet.As<IQueryable<City>>().Setup(m => m.Expression).Returns(cityData.Expression);
            mockSet.As<IQueryable<City>>().Setup(m => m.ElementType).Returns(cityData.ElementType);
            mockSet.As<IQueryable<City>>().Setup(m => m.GetEnumerator()).Returns(() => cityData.GetEnumerator());


            var weatherData = new List<WeatherData>
            {
                new WeatherData { Id=1, Status = "BBB", DangerLevel = 1 }
            }.AsQueryable();

            var weatherDataMockSet = new Mock<DbSet<WeatherData>>();
            mockSet.As<IQueryable<WeatherData>>().Setup(m => m.Provider).Returns(weatherData.Provider);
            mockSet.As<IQueryable<WeatherData>>().Setup(m => m.Expression).Returns(weatherData.Expression);
            mockSet.As<IQueryable<WeatherData>>().Setup(m => m.ElementType).Returns(weatherData.ElementType);
            mockSet.As<IQueryable<WeatherData>>().Setup(m => m.GetEnumerator()).Returns(() => weatherData.GetEnumerator());



            var cityWeatherData = new List<CityWeather>
            {
                new CityWeather { CityId=1, WeatherStatusId = 1 }
            }.AsQueryable();

            var cityWeatherDataMockSet = new Mock<DbSet<CityWeather>>();
            mockSet.As<IQueryable<CityWeather>>().Setup(m => m.Provider).Returns(cityWeatherData.Provider);
            mockSet.As<IQueryable<CityWeather>>().Setup(m => m.Expression).Returns(cityWeatherData.Expression);
            mockSet.As<IQueryable<CityWeather>>().Setup(m => m.ElementType).Returns(cityWeatherData.ElementType);
            mockSet.As<IQueryable<CityWeather>>().Setup(m => m.GetEnumerator()).Returns(() => cityWeatherData.GetEnumerator());
            var mockContext = new Mock<WeatherContext>();

            mockContext.Setup(c => c.Cities).Returns(mockSet.Object);
            mockContext.Setup(c => c.WeatherData).Returns(weatherDataMockSet.Object);
            mockContext.Setup(c => c.CityWeather).Returns(cityWeatherDataMockSet.Object);

            var service = new WeatherService(mockContext.Object);
            var cityWeatherList = service.GetWeatherDataResponse();

            Assert.AreEqual(1, cityWeatherList.Count);
            Assert.AreEqual("AAA", cityWeatherList[0].City);
            Assert.AreEqual(1, cityWeatherList[0].DangerLevel);
            Assert.AreEqual("BBB", cityWeatherList[0].WeatherStatus);
        }
    }
}