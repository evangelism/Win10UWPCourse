using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace OpenWeatherMap.ViewModel
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        public WeatherRecord Data { get; set; }

        public DetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var o = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherRecord>(e.Parameter.ToString());
            Data = o; //e.Parameter as WeatherRecord;
            if (Data == null) throw new Exception("PANIC!");
        }

        //private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var dataW = Newtonsoft.Json.JsonConvert.SerializeObject(Data);
           
        //    //Создаем объект диалога
        //    FileSavePicker savePicker = new FileSavePicker();
        //    savePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;

        //    // Предлагаем пользователю тип, в котором он может сохранить файл  
        //    savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });

        //    // Указываем имя файла по умолчанию, если пользователь не указал его или выбрал существующее
        //    savePicker.SuggestedFileName = "New Document";

        //    // Открываем диалог, чтобы пользователь сохранил файл
        //    Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();

        //    if (file != null)
        //    {
        //        // запись в файл 
        //        await FileIO.WriteTextAsync(file, dataW);
               
        //    }    
           
        //}
    }
}
