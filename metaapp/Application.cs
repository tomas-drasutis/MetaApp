using Metaapp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

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
            _weatherController.UpdateWeather(arguments);
        }
    }
}
