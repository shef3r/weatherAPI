using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

#pragma warning disable CS8618

namespace weatherAPI
{
    public class WeatherClient
    {
        internal class Daily
        {
            public List<string> time { get; set; }
            public List<int> weathercode { get; set; }
            public List<double> temperature_2m_max { get; set; }
            public List<double> temperature_2m_min { get; set; }
            public List<double> apparent_temperature_max { get; set; }
            public List<double> apparent_temperature_min { get; set; }
            public List<string> sunrise { get; set; }
            public List<string> sunset { get; set; }
            public List<double> windspeed_10m_max { get; set; }
            public List<int> winddirection_10m_dominant { get; set; }
        }

        internal class DailyUnits
        {
            public string time { get; set; }
            public string weathercode { get; set; }
            public string temperature_2m_max { get; set; }
            public string temperature_2m_min { get; set; }
            public string apparent_temperature_max { get; set; }
            public string apparent_temperature_min { get; set; }
            public string sunrise { get; set; }
            public string sunset { get; set; }
            public string windspeed_10m_max { get; set; }
            public string winddirection_10m_dominant { get; set; }
        }

        internal class Hourly
        {
            public List<string> time { get; set; }
            public List<double> temperature_2m { get; set; }
            public List<int> weathercode { get; set; }
            public List<double> windspeed_10m { get; set; }
            public List<int> winddirection_10m { get; set; }
        }

        internal class HourlyUnits
        {
            public string time { get; set; }
            public string temperature_2m { get; set; }
            public string weathercode { get; set; }
            public string windspeed_10m { get; set; }
            public string winddirection_10m { get; set; }
        }

        internal class Root
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
            public double generationtime_ms { get; set; }
            public int utc_offset_seconds { get; set; }
            public string timezone { get; set; }
            public string timezone_abbreviation { get; set; }
            public double elevation { get; set; }
            public HourlyUnits hourly_units { get; set; }
            public Hourly hourly { get; set; }
            public DailyUnits daily_units { get; set; }
            public Daily daily { get; set; }
        }

        public class HourlyForecast
        {
            public string time { get; set; }
            public double temperature { get; set; }
            public int weatherCode { get; set; }
            public double windSpeed { get; set; }
            public int windDirection { get; set; }
        }

        public class DailyForecast
        {
            public string time { get; set; }
            public double temperatureMax { get; set; }
            public double temperatureMin { get; set; }
            public int weatherCode { get; set; }
            public double apparentTemperatureMax { get; set; }
            public double apparentTemperatureMin { get; set; }
            public string sunrise { get; set; }
            public string sunset { get; set; }
            public double windSpeedMax { get; set; }
            public int windDirectionDominant { get; set; }
        }

        public class WeatherData
        {
            public List<HourlyForecast> HourlyForecasts { get; set; }
            public List<DailyForecast> DailyForecasts { get; set; }
            public weatherAPI.CitySearch.City City { get; set; }
        }

        public static async Task<WeatherData> WeatherSearch(weatherAPI.CitySearch.City city, bool useAmericanSystem)
        {
            if (useAmericanSystem == true)
            {
                throw new Exception("american stuff doesnt work yet");
            }
            else if (useAmericanSystem == false)
            {
                using HttpClient client = new HttpClient();
                string url = $"https://api.open-meteo.com/v1/forecast?latitude={city.latitude.ToString().Replace(",",".")}&longitude={city.longitude.ToString().Replace(",",".")}&hourly=temperature_2m,weathercode,windspeed_10m,winddirection_10m&daily=weathercode,temperature_2m_max,temperature_2m_min,apparent_temperature_max,apparent_temperature_min,sunrise,sunset,windspeed_10m_max,winddirection_10m_dominant&timezone=auto";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                Root root = JsonConvert.DeserializeObject<Root>(result);
                List<HourlyForecast> hourlyForecasts = new List<HourlyForecast>();
                for (int i = 0; i < root.hourly.time.Count; i++)
                {
                    HourlyForecast hourlyForecast = new HourlyForecast
                    {
                        time = root.hourly.time[i],
                        temperature = root.hourly.temperature_2m[i],
                        weatherCode = root.hourly.weathercode[i],
                        windSpeed = root.hourly.windspeed_10m[i],
                        windDirection = root.hourly.winddirection_10m[i]
                    };
                    hourlyForecasts.Add(hourlyForecast);
                }

                List<DailyForecast> dailyForecasts = new List<DailyForecast>();
                for (int i = 0; i < root.daily.time.Count; i++)
                {
                    DailyForecast dailyForecast = new DailyForecast
                    {
                        time = root.daily.time[i],
                        temperatureMax = root.daily.temperature_2m_max[i],
                        temperatureMin = root.daily.temperature_2m_min[i],
                        weatherCode = root.daily.weathercode[i],
                        apparentTemperatureMax = root.daily.apparent_temperature_max[i],
                        apparentTemperatureMin = root.daily.apparent_temperature_min[i],
                        sunrise = root.daily.sunrise[i],
                        sunset = root.daily.sunset[i],
                        windSpeedMax = root.daily.windspeed_10m_max[i],
                        windDirectionDominant = root.daily.winddirection_10m_dominant[i]
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

            throw new Exception();
        }
    }
}
