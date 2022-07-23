using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApplication.Client.Api;

namespace WindowsApplication.Interfaces
{
    public interface IOpenMailService
    {
        public void OpenMail(string mail);
    }
}
