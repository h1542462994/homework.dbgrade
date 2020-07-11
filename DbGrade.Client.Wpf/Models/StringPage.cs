using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tro.DbGrade.Client.Wpf.Models
{
    public class StringPage: INotifyPropertyChanged
    {
        public StringPage(string title)
        {
        }
        public StringPage(string title, Type pageType)
        {
            this.title = title;
            this.pageType = pageType;
        }

        private string title;
        public string Title { get => title; set
            {
                this.title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        private Type pageType;


        public Type PageType { get => pageType; set
            {
                this.pageType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PageType)));
            } 
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
