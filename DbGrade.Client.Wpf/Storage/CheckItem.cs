using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tro.DbGrade.Client.Wpf.Storage
{
    public class CheckItem<T> : INotifyPropertyChanged
    {
        private bool isChecked;
        private T data;

        public bool IsChecked { get => isChecked; set
            {
                isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsChecked)));
            } 
        }

        public T Data { get => data; set 
            {
                data = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Data)));
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
