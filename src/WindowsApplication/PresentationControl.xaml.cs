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





        public object[] Items
        {
            get { return (object[])GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(object[]), typeof(PresentationControl));


        public PresentationControl()
        {
            InitializeComponent();
            DataContext = new PresentationViewModel(Items);
        }

       
}
