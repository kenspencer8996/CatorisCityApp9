using CatorisCityAppNew.Objects;
using System.ComponentModel;

namespace CatorisCityAppNew.Viewmodels
{
    public class ViewmodelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        

        public void OnPropertyChanged(string propertyName)
        {
            if (Global.Loading == false)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
