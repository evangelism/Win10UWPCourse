using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sorting
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        int[] Data;
        Random Rnd = new Random();

        public MainPage()
        {
            this.InitializeComponent();
            Data = new int[30];
            for (int i = 0; i < 30; i++) Data[i] = Rnd.Next(0, 300);
            DataControl.ItemsSource = Data;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await Sort();
        }

        private async Task Sort()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                var x = Data[i];
                var k = i;
                for (int j = i + 1; j < Data.Length; j++)
                {
                    if (Data[j] < Data[k])
                    {
                        k = j;
                    }
                }
                Data[i] = Data[k];
                Data[k] = x;
                DataControl.ItemsSource = Data;
                await Task.Delay(1000);
            }
        }

    }

}
