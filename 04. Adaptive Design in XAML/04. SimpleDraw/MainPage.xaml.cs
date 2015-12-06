using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SimpleDraw
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            InkCanvas.InkPresenter.InputDeviceTypes =
                CoreInputDeviceTypes.Pen |
                CoreInputDeviceTypes.Mouse |
                CoreInputDeviceTypes.Touch;
        }

        private void ChangeColor(object sender, TappedRoutedEventArgs e)
        {
            var b = ((Ellipse)sender).Fill as SolidColorBrush;
            var da = new InkDrawingAttributes();
            da.Color = b.Color;
            InkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(da);
        }
    }
}
