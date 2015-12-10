using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OpenWeatherMap.ViewModel
{
    public class AbstractViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify([CallerMemberName] string f=null)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(f));
            }
        }

    }
}
