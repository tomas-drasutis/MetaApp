using Metaapp.Controllers;
using Metaapp.UI;
using Metaapp.Utilities;
using System.Threading.Tasks;

namespace Metaapp
{
    public class Application : IApplication
    {
        ITrigger _trigger;
        IWeatherDisplayer _displayer;

        public Application(ITrigger trigger, IWeatherDisplayer displayer)
        {
            _trigger = trigger;
            _displayer = displayer;
        }

        public void Run(string[] arguments)
        {
            _displayer.DisplayMessage("Starting application..");
           Task.Run(() =>_trigger.StartUpdate(arguments));
        }
    }
}
