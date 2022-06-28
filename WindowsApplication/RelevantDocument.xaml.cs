using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using WindowsApplication.DataObjects;
using WindowsApplication.ViewModules;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for RelevantDocument.xaml
    /// </summary>
    public partial class RelevantDocument : UserControl
    {
       public static readonly RoutedEvent AddClickEvent = EventManager.RegisterRoutedEvent(
            "AddClick",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(RelevantDocument)
        );

        public event RoutedEventHandler AddClick
        {
            add { AddHandler(AddClickEvent, value); }
            remove { RemoveHandler(AddClickEvent, value); }
        }
        
        public RelevantDocument()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AddClickEvent));
        }
    }
}
