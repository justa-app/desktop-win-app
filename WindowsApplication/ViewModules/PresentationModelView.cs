using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApplication.Utilities;

namespace WindowsApplication.ViewModules
{
    public class PresentationModelView : ObservableObject
    {
        private int _index;

        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                onPropertyChanged("Index");
            }
        }

        private object _item;

        public object Item {
            get => _item;
            set {
                _item = value;
                onPropertyChanged("Item");
            }
        }
    }
}
