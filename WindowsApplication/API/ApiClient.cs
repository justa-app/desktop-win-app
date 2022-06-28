using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

using WindowsApplication.Utilities;

using WindowsApplication.DataObjects;

namespace WindowsApplication.API
{
    // TODO use this on a seperate thread, or send only if finished typing, it takes a long time for response
    // TODO the http client is too coupled with the interface.
    public class ApiClient : ObservableObject
    {
        private RelevantDocumentData[] _lastResponse;
        public RelevantDocumentData[] LastUpdatedResponse
        {
            //get => _lastResponse;
            get => _lastResponse;
            private set {
                if (_lastResponse == value) return;
                _lastResponse = value;
                OnPropertyChanged("LastUpdatedResponse");

            }
        }
        private DateTime _lastUpdateTime;
        
        static readonly HttpClient client = new HttpClient();

        public ApiClient()
        {
            this.LastUpdatedResponse = new RelevantDocumentData[0];
        }

        public void Update(string data)
        {
            DateTime CurrentUpdateTime = DateTime.Now;
            this._checkRelevantDocuments(data).ContinueWith(r =>
            {
                if (r.Result != null && _lastUpdateTime < CurrentUpdateTime)
                {
                    _lastUpdateTime = CurrentUpdateTime;
                    LastUpdatedResponse = r.Result;
                }
            }
            );
        }

        private async Task<RelevantDocumentData[]?> _checkRelevantDocuments(string data)
        {
            try
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions.
                HttpResponseMessage response = await client.PostAsync(
                    "http://infra.askjusta.com/knowledge/",
                    content: new StringContent(data)
                );
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                RelevantDocumentData[]? responseData = JsonSerializer.Deserialize<RelevantDocumentData[]>(responseBody);
                return responseData;
            } catch (HttpRequestException ex)
            {
                Console.WriteLine("Exception happened with api request\nMessage: {0}", ex.Message);
                return null;
            }
        }
    }
}
