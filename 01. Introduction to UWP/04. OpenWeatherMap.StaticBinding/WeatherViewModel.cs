using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OpenWeatherMap.ViewModel
{

    public class WeatherRecord
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public DateTime When { get; set; }
        public BitmapImage Icon { get; set; }

        public string Date
        {
            get { return $"{When.Day:D2}.{When.Month:D2}"; }
        }
        
        public string FullDate
        {
            get { return When.ToString("D"); }
        }

    }


    public class WeatherViewModel : INotifyPropertyChanged
    {
        public string AppID = "2de143494c0b295cca9337e1e96b00e0";

        public int Temperature;
        public BitmapImage Pic;

        public ObservableCollection<WeatherRecord> Forecast = new ObservableCollection<WeatherRecord>();

        public async Task Load()
        {
            var cli = new HttpClient();
            var res = await cli.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=Moscow&mode=json&units=metric&APPID=" + AppID);
            dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(res);
            Temperature = x.main.temp;
            Pic = new BitmapImage(new Uri($"http://openweathermap.org/img/w/{x.weather[0].icon}.png"));
            if (PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs("Temperature"));
                PropertyChanged(this,new PropertyChangedEventArgs("Pic"));
            }
            res = await cli.GetStringAsync("http://api.openweathermap.org/data/2.5/forecast/daily?q=Moscow&mode=json&units=metric&cnt=7&APPID="+AppID);
            x = Newtonsoft.Json.JsonConvert.DeserializeObject(res);
            foreach (var z in x.list)
            {
                Forecast.Add(new WeatherRecord()
                {
                    When = Convert((long)z.dt),
                    Temp = z.temp.day,
                    Pressure = z.pressure,
                    Humidity = z.humidity,
                    Icon = new BitmapImage(new Uri($"http://openweathermap.org/img/w/{z.weather[0].icon}.png"))
                });
            }
        }

        private DateTime Convert(long x)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(x).ToLocalTime();
            return dtDateTime;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
