using Metaapp.DataLayer.Provider;
using Metaapp.DataLayer.Storage;
using Metaapp.Models;
using Metaapp.UI;
using Metaapp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Metaapp.Controllers
{
    public class WeatherController : IWeatherController
    {
        ILogger _logger;
        IStorage _storage;
        IWeatherProvider _provider;
        IWeatherDisplayer _displayer;

        public WeatherController(ILogger logger, IStorage storage, IWeatherProvider provider, IWeatherDisplayer displayer)
        {
            _logger = logger;
            _storage = storage;
            _provider = provider;
            _displayer = displayer;
            _storage.DataSaved += _displayer.Display;
        }

        public async Task UpdateWeather(string[] cityNames)
        {
            if (cityNames.Length == 0)
                throw new ArgumentException("Please provide startup arguments.");

            List<CityWeather> weatherList = new List<CityWeather>();
            List<Task<CityWeather>> taskList = new List<Task<CityWeather>>();

            _logger.Log("Fetching the list of cities!");
            string cities = _provider.GetCities();

            _logger.Log("Fetching weather data!");
            foreach (var cityName in cityNames)
            {
                if (!cities.Contains(cityName))
                    throw new ArgumentException($"The given city was not found: {cityName}. Please enter valid cities.");

                taskList.Add(Task.Run(() => _provider.GetCityWeather(cityName)));
            }

            weatherList = (await Task.WhenAll(taskList.ToArray())).OrderBy(x => x.City).ToList();
            _logger.Log($"Fetched information for {weatherList.Count()} cities.");

            _logger.Log("Saving weather data!");
            _storage.Save<CityWeather>(weatherList);
        }
    }
}
