using System.Text.Json.Serialization;
using weatherAPI.Models;

namespace weatherAPI
{
    [JsonSerializable(typeof(CitySearchResult))]
    [JsonSerializable(typeof(Root))]
    public sealed partial class WeatherJsonContext : JsonSerializerContext
    {
    }
}
