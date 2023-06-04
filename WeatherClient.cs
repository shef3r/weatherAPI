using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using weatherAPI.Models;

namespace weatherAPI
{
    public sealed class WeatherClient : IDisposable
    {
        public HttpClient Client { get; } = new();

        public static async Task<WeatherData> SearchWeatherAsync(City city, bool useAmericanSystem)
        {
            if (useAmericanSystem)
                throw new ArgumentException("american stuff doesnt work yet");

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={city.Latitude.ToString().Replace(",", ".")}&longitude={city.Longitude.ToString().Replace(",", ".")}&hourly=temperature_2m,weathercode,windspeed_10m,winddirection_10m&daily=weathercode,temperature_2m_max,temperature_2m_min,apparent_temperature_max,apparent_temperature_min,sunrise,sunset,windspeed_10m_max,winddirection_10m_dominant&timezone=auto";

            using var stream = await Client.GetStreamAsync(url);
            Root root = await JsonSerializer.DeserializeAsync(stream, WeatherJsonContext.Default.Root);

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

        public static async Task<List<City>> SearchCityAsync(string query, string limit, string langCode)
        {
            using var stream = await Client.GetStreamAsync($"https://geocoding-api.open-meteo.com/v1/search?name={query}&count={limit}&language={langCode}&format=json");

            CitySearchResult result = await JsonSerializer.DeserializeAsync(stream, WeatherJsonContext.Default.CitySearchResult);
            return result.Results;
        }

        public void Dispose()
            => Client.Dispose();
    }
}
