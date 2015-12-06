using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowGames
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        ApplicationView AV;
        int x = 500;
        int y = 500;

        public MainPage()
        {
            this.InitializeComponent();
            AV = ApplicationView.GetForCurrentView();
            AV.TryResizeView(new Size(x, y));            
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            var s = (string)((Button)sender).Tag;
            var a = s.Split(',');
            var dx = int.Parse(a[0]);
            var dy = int.Parse(a[1]);
            if (dx == 0 && dy == 0) AV.TryEnterFullScreenMode();
            else
            {
                x += dx;
                y += dy;
                AV.TryResizeView(new Size(x, y));
            }
        }

        private async void BtnCommand(object sender, RoutedEventArgs e)
        {
            var s = (string)((Button)sender).Tag;
            switch(s)
            {
                case "N":
                    int id = 0;
                    var v = Windows.ApplicationModel.Core.CoreApplication.CreateNewView();
                    await v.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                     {
                         var f = new Frame();
                         f.Navigate(typeof(MainPage));
                         Window.Current.Content = f;
                         Window.Current.Activate();
                         id = ApplicationView.GetForCurrentView().Id;
                     });
                    await ApplicationViewSwitcher.TryShowAsStandaloneAsync(id);
                    break;
            }
        }
    }
}
