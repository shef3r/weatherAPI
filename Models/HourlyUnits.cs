using System.Text.Json.Serialization;

namespace weatherAPI.Models
{
    public sealed class HourlyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string Temperature2Meter { get; set; }

        [JsonPropertyName("weathercode")]
        public string WeatherCode { get; set; }

        [JsonPropertyName("windspeed_10m")]
        public string WindSpeed10Meter { get; set; }

        [JsonPropertyName("winddirection_10m")]
        public string WindDirection10Meter { get; set; }
    }
}
