using System.Text.Json.Serialization;

namespace weatherAPI.Models
{
    public sealed class DailyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("weathercode")]
        public string WeatherCode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public string Temperature2MeterMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public string Temperature2MeterMin { get; set; }

        [JsonPropertyName("apparent_temperature_max")]
        public string ApparentTemperatureMax { get; set; }

        [JsonPropertyName("apparent_temperature_min")]
        public string ApparentTemperatureMin { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("windspeed_10m_max")]
        public string WindSpeed10MeterMax { get; set; }

        [JsonPropertyName("winddirection_10m_dominant")]
        public string WindDirection10MeterDominant { get; set; }
    }
}
