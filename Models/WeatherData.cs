using static weatherAPI.WeatherClient;
using System.Collections.Generic;

namespace weatherAPI.Models
{
    public sealed class WeatherData
    {
        public List<HourlyForecast> HourlyForecasts { get; set; }

        public List<DailyForecast> DailyForecasts { get; set; }

        public City City { get; set; }
    }
}
