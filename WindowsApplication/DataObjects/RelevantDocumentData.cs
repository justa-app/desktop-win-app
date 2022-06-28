using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsApplication.Utilities;

namespace WindowsApplication.DataObjects
{
    public class RelevantDocumentData : ObservableObject
    {
        public string title { get; set; }
        public string created_by { get; set; }
        public string type { get; set; }
        public string url { get; set; }

        public RelevantDocumentData(string title, string created_by, string type, string url)
        {
            this.title = title;
            this.created_by = created_by;
            this.type = type;
            this.url = url;
        }

        public override string ToString()
        {
            return String.Format("{0}-{1}-{2}-{3}", this.title, this.created_by, this.type, this.url);
        }

        public void GetDefaultBrowserPath(object sender, RoutedEventArgs e)
        {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            // get default browser path
            Process.Start(((string)registryKey.GetValue(null, null)).Split('"')[1], this.url);
        }
    }
}
