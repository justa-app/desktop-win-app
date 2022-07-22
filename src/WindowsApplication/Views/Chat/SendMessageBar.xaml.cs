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

namespace WindowsApplication.Views.Chat
{
    /// <summary>
    /// Interaction logic for SendMessageBar.xaml
    /// </summary>
    public partial class SendMessageBar : UserControl
    {

        public static readonly DependencyProperty SendMessageProperty =
        DependencyProperty.Register(
            "SendMessage",
            typeof(ICommand),
            typeof(SendMessageBar));

        public ICommand SendMessage
        {
            get { return (ICommand)GetValue(SendMessageProperty); }
            set { SetValue(SendMessageProperty, value); }
        }



        public string MessageText
        {
            get { return (string)GetValue(MessageTextProperty); }
            set { SetValue(MessageTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageTextProperty =
            DependencyProperty.Register("MessageText", typeof(string), typeof(SendMessageBar));



        public SendMessageBar()
        {
            InitializeComponent();

        }
    }
}
