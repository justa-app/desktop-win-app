﻿using System;
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
    public partial class MainWindow : InvisibleWindow
    {
        MainWindowViewModel _model;
        ContentWindow contentWindow;

        public MainWindow()
        {
            InitializeComponent();

            _model = new MainWindowViewModel();
            DataContext = _model;
            contentWindow = new ContentWindow(this) { DataContext = _model };
            contentWindow.Navigate(new MainPage(_model));
            
            // TODO improve the size Changed
            Top = 200;
            Left = 200;

            new Thread(_model.registerFocusChangeHandler).Start();
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
