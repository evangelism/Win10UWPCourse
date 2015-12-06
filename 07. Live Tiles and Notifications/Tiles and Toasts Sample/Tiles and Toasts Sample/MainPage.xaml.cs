using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Tiles_and_Toasts_Sample.Models;
using Tiles_and_Toasts_Sample.Services;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tiles_and_Toasts_Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void StartForecast_Click(object sender, RoutedEventArgs e)
        {
            UpdateTiles();
        }

        private void UpdateTiles()
        {
            var tileXML = TileService.CreateTile(WeatherForecast.GetForecast());
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            TileNotification notification = new TileNotification(tileXML);
            updater.Update(notification);

        }

        private void BreakingNews_Click(object sender, RoutedEventArgs e)
        {
            var toastXML = ToastService.CreateToast();
            var notifier = ToastNotificationManager.CreateToastNotifier();
            var toast = new ToastNotification(toastXML);
            notifier.Show(toast);

        }
    }
}
