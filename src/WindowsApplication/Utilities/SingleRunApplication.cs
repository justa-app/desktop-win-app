using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsApplication.Utilities
{
    public partial class SingleRunApplication : System.Windows.Application
    {
        private Mutex appRuns = null;

        public SingleRunApplication()
        {
            Startup += SingleRunApplication_Startup;
            Exit += SingleRunApplication_Exit;
        }

        private void SingleRunApplication_Startup(object sender, System.Windows.StartupEventArgs e)
        {
            bool createdNew;
            appRuns = new Mutex(true, "8fe8e6b4-29f7-43fc-8279-df34d7340eb1", out createdNew);

            if (!createdNew)
            {
                System.Windows.MessageBox.Show("A justa instance is already running");
                Environment.Exit(0);
            }
        }

        private void SingleRunApplication_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            appRuns.Dispose();
        }

        
    }
}
