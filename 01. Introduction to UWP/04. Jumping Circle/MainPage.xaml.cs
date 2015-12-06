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

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace JumpingCircle
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        Random Rnd = new Random();

        private void Tapped(object sender, TappedRoutedEventArgs e)
        {
            var x = Rnd.Next(0, (int)(Window.Current.Bounds.Width - ell.Width));
            var y = Rnd.Next(0, (int)(Window.Current.Bounds.Height - ell.Height));
            Canvas.SetLeft(ell, x);
            Canvas.SetTop(ell, y);
        }
    }
}
