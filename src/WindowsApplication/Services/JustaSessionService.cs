using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApplication.Client.Api;
using WindowsApplication.Interfaces;

namespace WindowsApplication.Services
{
    public class JustaSessionService : IJustaSessionService
    {
        public DefaultApi JustaApi { get; }

        public JustaSessionService()
        {
            JustaApi = new DefaultApi("https://infra.askjusta.com");
        }
    }
}
