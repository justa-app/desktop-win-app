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
    /// Interaction logic for ChatHeader.xaml
    /// </summary>
    public partial class ChatHeader : UserControl
    {


        public string Subject
        {
            get { return (string)GetValue(SubjectProperty); }
            set { SetValue(SubjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Subject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubjectProperty =
            DependencyProperty.Register("Subject", typeof(string), typeof(ChatHeader));


        public ChatHeader()
        {
            InitializeComponent();
        }
    }
}
