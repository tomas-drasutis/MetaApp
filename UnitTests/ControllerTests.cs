using Metaapp.Controllers;
using NUnit.Framework;
using Metaapp.Utilities;
using Metaapp.UI;
using Metaapp.DataLayer.Storage;
using Metaapp.DataLayer.Provider;
using System;
using Autofac.Extras.Moq;
using Metaapp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    public class ControllerTests
    {
        [Test]
        public async Task UpdateWeather_NoParameters_ThrowsExceptionAsync()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IWeatherProvider>()
                    .Setup(x => x.GetCities())
                    .Returns("Vilnius");

                mock.Mock<IWeatherProvider>()
                    .Setup(x => x.GetCityWeather("Vilnius"))
                    .Returns(GetSampleWeather()[0]);

                mock.Mock<IStorage>()
                    .Setup(x => x.Save(GetSampleWeather()));

                mock.Mock<IWeatherDisplayer>()
                    .Setup(x => x.DisplayMessage("one"));

                mock.Mock<ILogger>()
                    .Setup(x => x.Log("log"));

                var cls = mock.Create<WeatherController>();
                try
                {
                    await cls.UpdateWeather(Array.Empty<string>());
                    Assert.Fail("Did not throw Argument Exception when inappropriate cities were passed.");
                }
                catch (Exception ex)
                {
                    Assert.AreEqual(typeof(ArgumentException), ex.GetType(), "Wrong type of exception was thrown.");
                }
            }
        }

        [Test]
        public async Task UpdateWeather_InvalidParameters_ThrowsExceptionAsync()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IWeatherProvider>()
                    .Setup(x => x.GetCities())
                    .Returns("Vilnius");

                mock.Mock<IWeatherProvider>()
                    .Setup(x => x.GetCityWeather("Vilnius"))
                    .Returns(GetSampleWeather()[0]);

                mock.Mock<IStorage>()
                    .Setup(x => x.Save(GetSampleWeather()));

                mock.Mock<IWeatherDisplayer>()
                    .Setup(x => x.DisplayMessage("one"));

                mock.Mock<ILogger>()
                    .Setup(x => x.Log("log"));

                var cls = mock.Create<WeatherController>();
                try
                {
                    await cls.UpdateWeather(new string[] { "Kaunas" });                    
                    Assert.Fail("Did not throw Argument Exception when inappropriate cities were passed.");
                }
                catch (Exception ex)
                {
                    Assert.AreEqual(typeof(ArgumentException), ex.GetType(), "Wrong type of exception was thrown.");
                }
            }
        }

        [Test]
        public async Task UpdateWeather_Succeeds()
            {
            using (var mock = AutoMock.GetLoose())
                {
                mock.Mock<IWeatherProvider>()
                    .Setup(x => x.GetCities())
                    .Returns("Vilnius");

                mock.Mock<IWeatherProvider>()
                    .Setup(x => x.GetCityWeather("Vilnius"))
                    .Returns(GetSampleWeather()[0]);

                mock.Mock<IStorage>()
                    .Setup(x => x.Save(GetSampleWeather()));

                mock.Mock<IWeatherDisplayer>()
                    .Setup(x => x.DisplayMessage("one"));

                mock.Mock<ILogger>()
                    .Setup(x => x.Log("log"));

                var cls = mock.Create<WeatherController>();

                try
                    {
                    await cls.UpdateWeather(new string[] { "Vilnius" });
                    }
                catch (Exception ex)
                    {
                    Assert.Fail("Threw an exception when it should not have.");                    
                    }
                }
            }

        private List<CityWeather> GetSampleWeather()
        {
            List<CityWeather> output = new List<CityWeather>
            {
                new CityWeather
                {
                    City = "Vilnius",
                    Precipation = 10,
                    Temperature = 11,
                    TimeStamp = DateTime.Now,
                    Weather = "Fine"
                },
                new CityWeather
                {
                    City = "Ukmerge",
                    Precipation = 9,
                    Temperature = 1,
                    TimeStamp = DateTime.Now,
                    Weather = "Weathery"
                },
                new CityWeather
                {
                    City = "Siauliai",
                    Precipation = 61,
                    Temperature = -7,
                    TimeStamp = DateTime.Now,
                    Weather = "Meh"
                }
            };

            return output;
        }
    }
}