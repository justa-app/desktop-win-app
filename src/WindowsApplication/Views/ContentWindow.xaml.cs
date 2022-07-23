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

namespace WindowsApplication.Views
{
    /// <summary>
    /// Interaction logic for ContentWindow.xaml
    /// </summary>
    public partial class ContentWindow : NavigationWindow
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        private const int GWL_EX_STYLE = -20;
        private const int WS_EX_APPWINDOW = 0x00040000, WS_EX_TOOLWINDOW = 0x00000080;

        Window mainWindow;
        bool s;
        bool b;

        public ContentWindow(Window window)
        {
            b = false;
            s = false;
            InitializeComponent();
            mainWindow = window;
            //this.Navigating += ContentWindow_Navigating;
            this.LoadCompleted += ContentWindow_LoadCompleted;
            mainWindow.LocationChanged += ContentWindowResize;
        }

        private void ContentWindow_LoadCompleted(object sender, NavigationEventArgs e)
        {
            
                UpdateLayout();
                ContentWindowResize(sender, e);
            
        }

        private void ContentWindowResize(object? sender, EventArgs e)
        {
            this.Top = mainWindow.Top - this.ActualHeight + 10; // the 10 here is to be on top of the circle
            this.Left = mainWindow.Left - this.ActualWidth + mainWindow.ActualWidth / 2;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HideWindowFromAltTab();
            ContentWindowResize(sender, e);
        }

        private void HideWindowFromAltTab()
        {
            //Variable to hold the handle for the form
            var helper = new WindowInteropHelper(this).Handle;
            // Performing windows magic to set the window as both existing style and toolwindow style
            // tool windows are hidden from Alt+Tab
            SetWindowLong(helper, GWL_EX_STYLE, (GetWindowLong(helper, GWL_EX_STYLE) | WS_EX_TOOLWINDOW) & ~WS_EX_APPWINDOW);
        }
    }
}
