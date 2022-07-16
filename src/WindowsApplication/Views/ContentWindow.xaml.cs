using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsApplication.Utilities;

namespace WindowsApplication.Views
{
    /// <summary>
    /// Interaction logic for ContentWindow.xaml
    /// </summary>
    public partial class ContentWindow : InvisibleWindow
    {
        Window mainWindow;
        
        public ContentWindow(Window window)
        {
            InitializeComponent();
            mainWindow = window;
            //this.Navigating += ContentWindow_Navigating;
            NavFrame.LoadCompleted += ContentWindow_LoadCompleted;
            mainWindow.LocationChanged += ContentWindowResize;
        }

        private void ContentWindow_LoadCompleted(object sender, NavigationEventArgs e)
        {
                UpdateLayout();
                ContentWindowResize(sender, e);   
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ContentWindowResize(sender, e);
        }

        private void ContentWindowResize(object? sender, EventArgs e)
        {
            this.Top = mainWindow.Top - this.ActualHeight;
            this.Left = mainWindow.Left - this.ActualWidth + mainWindow.ActualWidth / 2;
        }
    }
}
