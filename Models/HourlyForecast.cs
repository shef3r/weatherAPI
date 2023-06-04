using System.Text.Json.Serialization;

namespace weatherAPI.Models
{
    public sealed class HourlyForecast
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonPropertyName("weatherCode")]
        public int WeatherCode { get; set; }

        [JsonPropertyName("windSpeed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("windDirection")]
        public int WindDirection { get; set; }
    }
}
