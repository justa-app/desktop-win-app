using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsApplication.Utilities;

namespace WindowsApplication.ViewModules
{
    class PresentationViewModel : ObservableCollection<object>
    {
        private int _index;
        public int Index { get => _index; set {
                _index = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Index"));
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("SelectedItem"));
            } 
        }

        public object SelectedItem
        {
            get => this[_index];
        }
    }
}
