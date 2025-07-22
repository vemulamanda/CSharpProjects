using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyMauiApp.ViewModel
{
    [INotifyPropertyChanged]
    public partial class BaseViewModel
    {
        bool isBusy;
        string title;

        //public bool IsBusy
        //{
        //    get => isBusy;
        //    set
        //    {
        //        if (isBusy == value)
        //            return;

        //        isBusy = value;
        //        OnPropertyChanged(nameof(isBusy));
        //    }
        //}

        //public string Title
        //{
        //    get => title;
        //    set
        //    {
        //        if(title == value) 
        //            return;

        //        title = value;
        //        OnPropertyChanged(nameof(title));
        //    }
        //}

        public bool IsNotBusy => !isBusy;

        //public event PropertyChangedEventHandler? PropertyChanged;

        //public void OnPropertyChanged([CallerMemberName]string name = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}
    }
}
