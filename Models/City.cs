﻿using System.Text.Json.Serialization;

namespace weatherAPI.Models
{
    public sealed class City
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("admin1")]
        public string Admin1 { get; set; } = string.Empty;
    }
}
