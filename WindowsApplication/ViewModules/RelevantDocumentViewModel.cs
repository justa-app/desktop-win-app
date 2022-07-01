using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WindowsApplication.Utilities;

namespace WindowsApplication.ViewModules
{
    public class RelevantDocumentViewModel : ObservableObject
    {
        public string title { get; set; }
        public string created_by { get; set; }
        public string type { get; set; }
        public string url { get; set; }

        public ICommand OpenBrowserCommand { get; private set; }

        public RelevantDocumentViewModel(string title, string created_by, string type, string url)
        {
            this.title = title;
            this.created_by = created_by;
            this.type = type;
            this.url = url;
            this.OpenBrowserCommand = new RelayCommand(OpenBrowser);
        }

        public override string ToString()
        {
            return String.Format("{0}-{1}-{2}-{3}", this.title, this.created_by, this.type, this.url);
        }

        public void OpenBrowser()
        {
            //TODO use https://brockallen.com/2016/09/24/process-start-for-urls-on-net-core/
            // and probably make it a command
            ProcessStartInfo info = new ProcessStartInfo(url);
            info.UseShellExecute = true;
            Process.Start(info);
        }
    }
}
