using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsApplication.Interfaces;
using WindowsApplication.Services;
using WindowsApplication.Utilities;

namespace WindowsApplication.Dialogs.YesNo
{
    public class YesNoDialogViewModel : DialogViewModelBase<DialogResults>
    {
        public ICommand YesCommand { get; private set; }
        public ICommand NoCommand { get; private set; }

        public YesNoDialogViewModel(string title, string message) : base(title, message)
        {
            YesCommand = new RelayCommand<IDialogWindow>(Yes);
            NoCommand = new RelayCommand<IDialogWindow>(No);
        }

        private void Yes(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.Yes);
        }
        private void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResults.No);
        }
    }
}
