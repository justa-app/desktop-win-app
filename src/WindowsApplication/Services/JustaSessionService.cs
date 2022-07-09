using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            HttpClient client = new HttpClient(handler);

            JustaApi = new DefaultApi(client, "https://infra.askjusta.com/chat");
        }
    }
}
