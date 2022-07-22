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
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : UserControl
    {



        public Boolean IsOrigin
        {
            get { return (Boolean)GetValue(IsOriginProperty); }
            set { SetValue(IsOriginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOrigin.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOriginProperty =
            DependencyProperty.Register("IsOrigin", typeof(Boolean), typeof(Message));




        public CornerRadius Radius
        {
            get { return (CornerRadius)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Radius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(CornerRadius), typeof(Message));



        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(Brush), typeof(Message));




        public Brush MessageBackground
        {
            get { return (Brush)GetValue(MessageBackgroundProperty); }
            set { SetValue(MessageBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageBackgroundProperty =
            DependencyProperty.Register("MessageBackground", typeof(Brush), typeof(Message));



        public String MessageText
        {
            get { return (String)GetValue(MessageTextProperty); }
            set { SetValue(MessageTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageTextProperty =
            DependencyProperty.Register("MessageText", typeof(String), typeof(Message));



        public Message()
        {
            InitializeComponent();
        }
    }
}
