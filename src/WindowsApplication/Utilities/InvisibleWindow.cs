using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace WindowsApplication.Utilities
{
    public partial class InvisibleWindow : Window
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        private const int GWL_EX_STYLE = -20;
        private const int WS_EX_APPWINDOW = 0x00040000, WS_EX_TOOLWINDOW = 0x00000080;


        public InvisibleWindow()
        {
            this.ShowInTaskbar = false;
            this.AllowsTransparency = true;
            this.WindowStyle = WindowStyle.None;
            this.Background = Brushes.Transparent;
            this.Loaded += InvisibleWindow_Loaded;
        }

        private void InvisibleWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HideWindowFromAltTab();
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