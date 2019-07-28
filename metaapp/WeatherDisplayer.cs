﻿using Metaapp.DataLayer.Storage;
using Metaapp.Models;
using Metaapp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metaapp
{
    class WeatherDisplayer : IWeatherDisplayer
    {
        ILogger _logger;
        IStorage _storage;

        public WeatherDisplayer(ILogger logger, IStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        public void Display()
        {
            Console.Clear();

            _logger.Log("Printing weather information.");
            Console.WriteLine("{0,15}|{1,15}|{2,15}|{3,15}|{4,20}", "City ", "Temperature ", "Precipation ", "Weather ", "Timestamp ");
            Console.Out.WriteLine("----------------------------------------------------------------------------------------");
            try
            {
                foreach (var item in _storage.Read<CityWeather>())
                {
                    Console.WriteLine($"{item.City,15}|" +
                        $"{item.Temperature,15}|" +
                        $"{item.Precipation,15}|" +
                        $"{item.Weather,15}|" +
                        $"{item.TimeStamp.TimeOfDay,20}");
                }
            }
            catch (Exception e)
            {
                _logger.Log(e.Message);
            }            
        }
    }
}
