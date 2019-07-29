using Metaapp.Controllers;
using Metaapp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Metaapp.Utilities
{
    public class UpdateTrigger : IUpdateTrigger
    {
        IWeatherController _weatherController;
        IWeatherDisplayer _weatherDisplayer;
        ILogger _logger;

        public UpdateTrigger(IWeatherController weatherController, IWeatherDisplayer weatherDisplayer, ILogger logger)
        {
            _weatherController = weatherController;
            _weatherDisplayer = weatherDisplayer;
            _logger = logger;
        }

        public async void StartUpdate(string[] cityNames)
        {
            try
            {
                await _weatherController.UpdateWeather(cityNames);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
                _weatherDisplayer.DisplayMessage(ex.Message);
            }
        }
    }
}
