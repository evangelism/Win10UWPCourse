using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiles_and_Toasts_Sample.Models
{
    public class WeatherForecast
    {
        public static DailyForecast[] GetForecast()
        {
            var forecast = new DailyForecast[]
            {
                new DailyForecast()
                {
                    weekday = "Mon",
                    daytemp = "+6",
                    nighttemp = "+2",
                    weather = "Cloudy"
                },
                new DailyForecast()
                {
                    weekday = "Tue",
                    daytemp = "+2°",
                    nighttemp = "-2°",
                    weather = "Sunny"
                },
                new DailyForecast()
                {
                    weekday = "Wed",
                    daytemp = "0°",
                    nighttemp = "-2°",
                    weather = "Mostly Cloudy"
                },
                new DailyForecast()
                {
                    weekday = "Thu",
                    daytemp = "+2°",
                    nighttemp = "0°",
                    weather = "Cloudy"
                },
                new DailyForecast()
                {
                    weekday = "Fri",
                    daytemp = "+2°",
                    nighttemp = "0°",
                    weather = "Drizzle"
                },
                new DailyForecast()
                {
                    weekday = "Sat",
                    daytemp = "0°",
                    nighttemp = "0°",
                    weather = "Cloudy"
                },
                new DailyForecast()
                {
                    weekday = "Sun",
                    daytemp = "+1°",
                    nighttemp = "-3°",
                    weather = "Snow"
                },
            };
            return forecast;
        }
    }

    public class DailyForecast
    {
        public string city { get; set; } = "Moscow";
        public string weekday { get; set; } = "Mon";
        public string daytemp { get; set; } = "+6°";
        public string nighttemp { get; set; } = "+3°";
        public string weather { get; set; } = "Cloudy";
    }
}
