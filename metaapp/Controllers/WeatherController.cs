﻿using Metaapp.DataLayer.Provider;
using Metaapp.DataLayer.Storage;
using Metaapp.Models;
using Metaapp.UI;
using Metaapp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Metaapp.Controllers
{
    class WeatherController : IWeatherController
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

        public void UpdateWeather(string[] cityNames)
        {
            try
            {
                if(cityNames.Length == 0)
                    throw new ArgumentException("Please provide startup arguments.");

                List<CityWeather> weatherList = new List<CityWeather>();
                CityWeather weather;

                _logger.Log("Fetching the list of cities!");
                string cities = _provider.GetCities();

                _logger.Log("Fetching weather data!");
                foreach (var cityName in cityNames)
                {
                    if (!cities.Contains(cityName))
                        throw new ArgumentException($"The given city was not found: {cityName}. Please enter valid cities.");

                    weather = _provider.GetCityWeather(cityName);
                    weather.TimeStamp = DateTime.Now;

                    weatherList.Add(weather);
                    _logger.Log($"Received object: { weather.City}, {weather.Temperature}, { weather.Precipation}, {weather.Weather}, {weather.TimeStamp.TimeOfDay}");
                }

                _logger.Log("Saving weather data!");
                _storage.Save<CityWeather>(weatherList);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
                _displayer.DisplayMessage(ex.Message);
                return;
            }

            new Timer(x => UpdateWeather(cityNames), null, 5000, Timeout.Infinite);

        }
    }
}
