using Metaapp.Models;

namespace Metaapp.DataLayer.Provider
{
    public interface IWeatherProvider
    {
        string GetCities();
        CityWeather GetCityWeather(string cityName);
    }
}