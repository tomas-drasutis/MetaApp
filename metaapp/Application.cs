using Metaapp.Controllers;
using Metaapp.UI;
using Metaapp.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Metaapp
    {
    public class Application : IApplication
        {
        IUpdateTrigger _trigger;
        IWeatherDisplayer _displayer;

        public Application(IUpdateTrigger UpdateTrigger, IWeatherDisplayer displayer)
            {
            _trigger = UpdateTrigger;
            _displayer = displayer;
            }

        public void Run(string[] arguments)
            {
            _displayer.DisplayMessage("Starting application..");
            Task.Run(() => _trigger.StartUpdate(arguments));
            new TimerTrigger(_trigger, 30000, arguments);
            }
        }
    }
