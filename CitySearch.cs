using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace weatherAPI;
public class CitySearch
{
    public class City
    {
        public string name { get; set; } = string.Empty;
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string country { get; set; } = string.Empty; 
        public string admin1 { get; set; } = string.Empty;
    }

    internal class Root
    {
        public List<City> results { get; set; } = new List<City>();
    }

    public static async Task<List<City>> CitySearcher(string query, string limit, string langCode)
    {
        using HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync($"https://geocoding-api.open-meteo.com/v1/search?name={query}&count={limit}&language={langCode}&format=json");
        response.EnsureSuccessStatusCode();
        string result = await response.Content.ReadAsStringAsync();
        Root root = JsonConvert.DeserializeObject<Root>(result);
        return root.results;
    }
}
