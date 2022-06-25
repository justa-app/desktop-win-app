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


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(RelevantDocument), new PropertyMetadata(string.Empty));




        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(RelevantDocument), new PropertyMetadata(String.Empty));




        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Url.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register("Url", typeof(string), typeof(RelevantDocument), new PropertyMetadata(string.Empty));


        public RelevantDocument()
        {
            InitializeComponent();
        }

        public RelevantDocument(String Title, String Description, String Url)
        {
            InitializeComponent();
            this.Title = Title;
            this.Description = Description;
            this.Url = Url;

        }

        private string GetDefaultBrowserPath()
        {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            // get default browser path
            return ((string)registryKey.GetValue(null, null)).Split('"')[1];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(GetDefaultBrowserPath(), this.Url);
        }
    }
}
