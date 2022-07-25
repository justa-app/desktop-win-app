using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApplication.Interfaces;

namespace WindowsApplication.Services
{
    public class OpenMailService : IOpenMailService
    {
        public void OpenMail(string mail)
        {
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("mailto:"+mail);
            info.UseShellExecute = true;
            System.Diagnostics.Process.Start(info);
        }
    }
}
