using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsApplication.API;
using WindowsApplication.AutomationHandlers;
using WindowsApplication.Utilities;
using WindowsApplication.ViewModules;
using WindowsApplication.Views;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        private const int GWL_EX_STYLE = -20;
        private const int WS_EX_APPWINDOW = 0x00040000, WS_EX_TOOLWINDOW = 0x00000080;


        MainWindowViewModel _model;

        public MainWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));

            _model = new MainWindowViewModel();
            DataContext = _model;
            _mainFrame.NavigationService.Navigate(new MainPage(_model));
            // TODO improve the size Changed
            SizeChanged += MainWindow_SizeChanged;

            Top = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Bottom - 200;
            Left = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Right - 200;
            

            new Thread(_model.registerFocusChangeHandler).Start();
            
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Left -= (e.NewSize.Width - e.PreviousSize.Width);
            Top -= (e.NewSize.Height - e.PreviousSize.Height);
        }

        private void HideWindowFromAltTab()
        {
            //Variable to hold the handle for the form
            var helper = new WindowInteropHelper(this).Handle;
            // Performing windows magic to set the window as both existing style and toolwindow style
            // tool windows are hidden from Alt+Tab
            SetWindowLong(helper, GWL_EX_STYLE, (GetWindowLong(helper, GWL_EX_STYLE) | WS_EX_TOOLWINDOW) & ~WS_EX_APPWINDOW);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HideWindowFromAltTab();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _model.ShowContent = !_model.ShowContent;
            _model.NewData = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new Thread(_model.unregisterFocusChangeHandler).Start();
        }

        Point _startPoint;
        void Icon_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        void Icon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(null);
        }

        void Icon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(null);
            if (Math.Abs(position.X - _startPoint.X) > SystemParameters.MinimumHorizontalDragDistance ||
                        Math.Abs(position.Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                e.Handled = true;
                // TODO set a normal horizontal/vertical drag size
            } else
            {
                // TODO this should not be here, it should be at it's own mouseup handle.
                Image_MouseLeftButtonUp(sender, e);
            }
        }
    }
}
