using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace weatherAPI.Models
{
    public sealed class DailyForecast
    {
        public string Time { get; set; }

        public double TemperatureMax { get; set; }

        public double TemperatureMin { get; set; }

        public int WeatherCode { get; set; }

        public double ApparentTemperatureMax { get; set; }

        public double ApparentTemperatureMin { get; set; }

        public string Sunrise { get; set; }

        public string Sunset { get; set; }

        public double WindSpeedMax { get; set; }

        public int WindDirectionDominant { get; set; }
    }
}
