using Metaapp.Controllers;
using Metaapp.UI;
using System.Threading.Tasks;

namespace Metaapp
{
    public class Application : IApplication
    {
        IWeatherController _weatherController;
        IWeatherDisplayer _weatherDisplayer;

        public Application(IWeatherController weatherController, IWeatherDisplayer weatherDisplayer)
        {
            _weatherController = weatherController;
            _weatherDisplayer = weatherDisplayer;
        }

        public void Run(string[] arguments)
        {
            Task.Run(() => _weatherDisplayer.DisplayMessage("Starting application..."));
            Task.Run(() => _weatherController.UpdateWeather(arguments));            
        }
    }
}
