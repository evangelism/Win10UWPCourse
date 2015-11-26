using System;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OpenWeatherMap.Simple
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string AppID = "2de143494c0b295cca9337e1e96b00e0";

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var cli = new HttpClient();
            var res = await cli.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=Moscow&mode=json&units=metric&APPID="+AppID);
            dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(res);
            Temp.Text = x.main.temp.ToString();
            BitmapImage img = new BitmapImage(new Uri($"http://openweathermap.org/img/w/{x.weather[0].icon}.png"));
            Img.Source = img;
        }
    }
}
