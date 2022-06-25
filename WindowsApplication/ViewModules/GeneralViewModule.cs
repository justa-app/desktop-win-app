using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApplication.Utilities;

namespace WindowsApplication.ViewModules
{
    public class GeneralViewModule : ObservableObject
    {
        private object _items; 

        public object Items
        {
            set
            {
                _items = value;
                onPropertyChanged("Items");
            }
            get => _items;
        }
    }
}
