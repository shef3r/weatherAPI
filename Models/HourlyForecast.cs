using System.Text.Json.Serialization;

namespace weatherAPI.Models
{
    public sealed class HourlyForecast
    {
        public string Time { get; set; }

        public double Temperature { get; set; }

        public int WeatherCode { get; set; }

        public double WindSpeed { get; set; }

        public int WindDirection { get; set; }
    }
}
