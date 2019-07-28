using Metaapp.Models;

namespace Metaapp.DataLayer.Provider
{
    interface IWeatherProvider
    {
        string GetCities();
        CityWeather GetCityWeather(string cityName);
    }
}