using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WindowsApplication.Interfaces;
using WindowsApplication.Utilities;

namespace WindowsApplication.Services
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : InvisibleWindow, IDialogWindow
    {
        public DialogWindow()
        {
            InitializeComponent();

            App.Current.MainWindow.IsVisibleChanged += Origin_IsVisibleChanged;
            this.Closed += DialogWindow_Closed;
        }

        private void DialogWindow_Closed(object sender, EventArgs e)
        {
            App.Current.MainWindow.IsVisibleChanged -= Origin_IsVisibleChanged;
        }

        private void Origin_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Hidden;
        }
    }
}