using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApplication.Interfaces;

namespace WindowsApplication.Services
{
    public class DialogService : IDialogService
    {
        public T OpenDialog<T>(DialogViewModelBase<T> viewModel)
        {
            // TODO this should be changed depending whether we want to follow the user of not
            IDialogWindow window = new DialogWindow();
            window.DataContext = viewModel;
            window.Show();
            return viewModel.DialogResult;
        }
    }
}