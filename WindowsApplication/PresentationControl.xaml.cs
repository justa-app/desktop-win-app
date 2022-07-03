using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsApplication.Utilities;
using WindowsApplication.ViewModules;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for PresentationControl.xaml
    /// </summary>
    public partial class PresentationControl : UserControl
    {
        // TODO move to a view model
        /*
         * Size
         * Item
         * IncreaseIndex
         * StartChat
         */

        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Size.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(PresentationControl));



        public object Item
        {
            get { return (object)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Item.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register("Item", typeof(object), typeof(PresentationControl), new PropertyMetadata(0));



        public PresentationControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static readonly RoutedEvent DecreaseIndexEvent = EventManager.RegisterRoutedEvent(
            "StartChat",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(PresentationControl)
        );

        public event RoutedEventHandler DecreaseIndex
        {
            add { AddHandler(DecreaseIndexEvent, value); }
            remove { RemoveHandler(DecreaseIndexEvent, value); }
        }

        public static readonly RoutedEvent IncreaseIndexEvent = EventManager.RegisterRoutedEvent(
            "IncreaseIndex",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(PresentationControl)
        );

        public event RoutedEventHandler IncreaseIndex
        {
            add { AddHandler(IncreaseIndexEvent, value); }
            remove { RemoveHandler(IncreaseIndexEvent, value); }
        }

        private void IncreaseIndexClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(IncreaseIndexEvent));
        }

        private void DecreaseIndexClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(DecreaseIndexEvent));
        }
    }
}
