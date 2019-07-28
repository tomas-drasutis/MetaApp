using System;

namespace Metaapp.UI
{
    public interface IWeatherDisplayer
    {
        void Display(object sender, EventArgs args);
        void DisplayMessage(string message);
    }
}
