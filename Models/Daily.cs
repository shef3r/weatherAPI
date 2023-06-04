using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace weatherAPI.Models
{
    public sealed class Daily
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> WeatherCode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double> Temperature2MeterMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double> Temperature2MeterMin { get; set; }

        [JsonPropertyName("apparent_temperature_max")]
        public List<double> ApparentTemperatureMax { get; set; }

        [JsonPropertyName("apparent_temperature_min")]
        public List<double> ApparentTemperatureMin { get; set; }

        [JsonPropertyName("sunrise")]
        public List<string> Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public List<string> Sunset { get; set; }

        [JsonPropertyName("windspeed_10m_max")]
        public List<double> WindSpeed10MeterMax { get; set; }

        [JsonPropertyName("winddirection_10m_dominant")]
        public List<int> WindDirection10MeterDominant { get; set; }
    }
}
