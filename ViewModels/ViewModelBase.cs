using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void PropertyChange([CallerMemberName] string propertyName = "") 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        protected string _title;
        public string Title
        {
            get => _title;
            protected set
            {
                if (_title != value)
                {
                    _title = value;
                    PropertyChange();
                }
            }
        }
    }
}
