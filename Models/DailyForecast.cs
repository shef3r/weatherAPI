using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace weatherAPI.Models
{
    public sealed class DailyForecast
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperatureMax")]
        public double TemperatureMax { get; set; }

        [JsonPropertyName("temperatureMin")]
        public double TemperatureMin { get; set; }

        [JsonPropertyName("weatherCode")]
        public int WeatherCode { get; set; }

        [JsonPropertyName("apparentTemperatureMax")]
        public double ApparentTemperatureMax { get; set; }

        [JsonPropertyName("apparentTemperatureMin")]
        public double ApparentTemperatureMin { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("windSpeedMax")]
        public double WindSpeedMax { get; set; }

        [JsonPropertyName("windDirectionDominant")]
        public int WindDirectionDominant { get; set; }
    }
}
