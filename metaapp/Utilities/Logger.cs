using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Metaapp.Utilities
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
