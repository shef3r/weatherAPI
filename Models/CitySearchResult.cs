using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace weatherAPI.Models
{
    public sealed class CitySearchResult
    {
        [JsonPropertyName("results")]
        public List<City> Results { get; set; }
    }
}
