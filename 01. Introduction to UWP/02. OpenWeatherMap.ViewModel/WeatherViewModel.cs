using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OpenWeatherMap.ViewModel
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        public string AppID = "2de143494c0b295cca9337e1e96b00e0";

        public int Temperature;
        public BitmapImage Pic;

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
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
