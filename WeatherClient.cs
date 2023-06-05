using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using weatherAPI.Models;

namespace weatherAPI
{
    public static class WeatherClient
    {
        private static HttpClient _client { get; } = new();

        internal static async Task<Root> DownloadWeatherData(bool useAmericanMeasurments, City city)
        {
            string url = null;
            ;
            if (useAmericanMeasurments)
            {
                url = $"https://api.open-meteo.com/v1/forecast?latitude={city.Latitude.ToString().Replace(",", ".")}&longitude={city.Longitude.ToString().Replace(",", ".")}&hourly=temperature_2m,weathercode,windspeed_10m,winddirection_10m&daily=weathercode,temperature_2m_max,temperature_2m_min,apparent_temperature_max,apparent_temperature_min,sunrise,sunset,windspeed_10m_max,winddirection_10m_dominant&timezone=auto&temperature_unit=fahrenheit&windspeed_unit=mph&precipitation_unit=inch";
            }
            else
            {
                url = $"https://api.open-meteo.com/v1/forecast?latitude={city.Latitude.ToString().Replace(",", ".")}&longitude={city.Longitude.ToString().Replace(",", ".")}&hourly=temperature_2m,weathercode,windspeed_10m,winddirection_10m&daily=weathercode,temperature_2m_max,temperature_2m_min,apparent_temperature_max,apparent_temperature_min,sunrise,sunset,windspeed_10m_max,winddirection_10m_dominant&timezone=auto";
            }
            using var stream = await _client.GetStreamAsync(url);
            return await JsonSerializer.DeserializeAsync(stream, WeatherJsonContext.Default.Root);
        }

        public static async Task<WeatherData> SearchWeatherAsync(City city, bool useAmericanSystem)
        {
            Root root = await DownloadWeatherData(useAmericanSystem, city);
            var hourlyForecasts = new List<HourlyForecast>();

            for (int i = 0; i < root.Hourly.Time.Count; i++)
            {
                var hourlyForecast = new HourlyForecast
                {
                    Time = root.Hourly.Time[i],
                    Temperature = root.Hourly.Temperature2Meter[i],
                    WeatherCode = root.Hourly.WeatherCode[i],
                    WindSpeed = root.Hourly.WindSpeed10Meter[i],
                    WindDirection = root.Hourly.WindDirection10Meter[i]
                };

                hourlyForecasts.Add(hourlyForecast);
            }

            var dailyForecasts = new List<DailyForecast>();

            for (int i = 0; i < root.Daily.Time.Count; i++)
            {
                var dailyForecast = new DailyForecast
                {
                    Time = root.Daily.Time[i],
                    TemperatureMax = root.Daily.Temperature2MeterMax[i],
                    TemperatureMin = root.Daily.Temperature2MeterMin[i],
                    WeatherCode = root.Daily.WeatherCode[i],
                    ApparentTemperatureMax = root.Daily.ApparentTemperatureMax[i],
                    ApparentTemperatureMin = root.Daily.ApparentTemperatureMin[i],
                    Sunrise = root.Daily.Sunrise[i],
                    Sunset = root.Daily.Sunset[i],
                    WindSpeedMax = root.Daily.WindSpeed10MeterMax[i],
                    WindDirectionDominant = root.Daily.WindDirection10MeterDominant[i]
                };

                dailyForecasts.Add(dailyForecast);
            }

            return new WeatherData
            {
                HourlyForecasts = hourlyForecasts,
                DailyForecasts = dailyForecasts,
                City = city
            };
        }

        public static async Task<List<City>> SearchCityAsync(string query, int limit, string langCode)
        {
            using var stream = await _client.GetStreamAsync($"https://geocoding-api.open-meteo.com/v1/search?name={query}&count={limit.ToString()}&language={langCode}&format=json");

            CitySearchResult result = await JsonSerializer.DeserializeAsync(stream, WeatherJsonContext.Default.CitySearchResult);
            return result.Results;
        }
    }
}
