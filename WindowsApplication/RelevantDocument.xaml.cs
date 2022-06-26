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
        public string title { get; set; }
        public string created_by { get; set; }
        public string type { get; set; }
        public string url { get; set; }

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
        
        public RelevantDocument(string title, string created_by, string type, string url)
        {
            InitializeComponent();
            this.title = title;
            this.created_by = created_by;
            this.type = type;
            this.url = url;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(AddClickEvent));
        }
    }
}
