using System.Threading.Tasks;

namespace Metaapp.Controllers
{
    public interface IWeatherController
    {
        Task UpdateWeather(string[] cityNames);
    }
}