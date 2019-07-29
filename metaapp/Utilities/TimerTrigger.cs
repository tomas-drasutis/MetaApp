using System;
using System.Timers;
using System.Threading.Tasks;

namespace Metaapp.Utilities
    {
    public class TimerTrigger
        {
        IUpdateTrigger _trigger;
        string[] _arguments;
        double _interval;
        Timer _timer;

        public TimerTrigger(IUpdateTrigger UpdateTrigger, double interval, string[] arguments)
            {
            _trigger = UpdateTrigger;
            _interval = interval;
            _arguments = arguments;
            _timer = new Timer(interval);

            _timer.Elapsed += TimerEventProcessor;
            _timer.Start();
            }

        private void TimerEventProcessor(object myObject, EventArgs myEventArgs)
            {
            Task.Run(() => _trigger.StartUpdate(_arguments));
            _timer.Interval = _interval;
            _timer.Start();
            }
        }
    }
