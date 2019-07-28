using System;
using System.Collections.Generic;
using System.Text;
using Metaapp.Models;
using RestSharp;

namespace Metaapp.DataLayer.Provider
{
    class WeatherProvider : IWeatherProvider
    {
        private string _baseUrl = "https://metasite-weather-api.herokuapp.com/api/";
        private RestClient _client = new RestClient();

        public string GetCities()
        {
            return _client.Execute(new RestRequest(_baseUrl + "Cities")).Content;
        }

        public CityWeather GetCityWeather(string cityName)
        {
            var weather = _client.Execute<CityWeather>(new RestRequest(_baseUrl + $"Weather/{cityName}")).Data;
            weather.TimeStamp = DateTime.Now;
            return weather;
        }
    }
}
