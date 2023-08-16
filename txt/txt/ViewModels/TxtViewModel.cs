using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace txt.ViewModels
{
    class TxtViewModel : INotifyPropertyChanged
    {
        private string _path;

        public string Path
        {
            get => _path;
            set
            {
                if (value != _path)
                {
                    _path = value;
                    OnPropertyChanged();
                }
            }
        }
       // public string HiText => "Hello, you are in";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string
            propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
