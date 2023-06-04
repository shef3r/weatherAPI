using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace weatherAPI.Models
{
    public sealed class Hourly
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature2Meter { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> WeatherCode { get; set; }

        [JsonPropertyName("windspeed_10m")]
        public List<double> WindSpeed10Meter { get; set; }

        [JsonPropertyName("winddirection_10m")]
        public List<int> WindDirection10Meter { get; set; }
    }
}
