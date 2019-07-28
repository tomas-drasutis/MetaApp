using System;
using Newtonsoft.Json;

namespace Metaapp.Models
{
    public class CityWeather
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("precipitation")]
        public int Precipation { get; set; }

        [JsonProperty("weather")]
        public string Weather { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
