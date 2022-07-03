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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for ExpertContent.xaml
    /// </summary>
    public partial class ExpertContent : UserControl
    {
        public static readonly RoutedEvent StartChatEvent = EventManager.RegisterRoutedEvent(
            "StartChatEvent",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(PresentationControl)
        );

        public event RoutedEventHandler StartChat
        {
            add { AddHandler(StartChatEvent, value); }
            remove { RemoveHandler(StartChatEvent, value); }
        }

        public ExpertContent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(StartChatEvent));
        }
    }
}
