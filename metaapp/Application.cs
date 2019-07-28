using System;
using Metaapp.Controllers;
using System.Threading.Tasks;

namespace Metaapp
{
    public class Application : IApplication
    {
        IWeatherController _weatherController;

        public Application(IWeatherController weatherController)
        {
            _weatherController = weatherController;
        }

        public void Run(string[] arguments)
        {
            Console.Out.WriteLine("Starting application..");
            Task.Run(() => _weatherController.UpdateWeather(arguments));            
        }
    }
}
