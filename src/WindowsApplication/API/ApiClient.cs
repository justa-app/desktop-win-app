﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

using WindowsApplication.Utilities;

using WindowsApplication.ViewModules;

namespace WindowsApplication.API
{
    // TODO use this on a seperate thread, or send only if finished typing, it takes a long time for response
    // TODO the http client is too coupled with the interface.
    public class ApiClient : ObservableObject
    {
        private RelevantDocumentViewModel[] _lastResponse;
        public RelevantDocumentViewModel[] LastUpdatedResponse
        {
            //get => _lastResponse;
            get => _lastResponse;
            private set
            {
                if (_lastResponse == value) return;
                _lastResponse = value;
                OnPropertyChanged("LastUpdatedResponse");

            }
        }
        private DateTime _lastUpdateTime;


        public static HttpClient client { get; private set; } = new();
        public ApiClient()
        {

            this.LastUpdatedResponse = new RelevantDocumentViewModel[0];
        }

        public void Update(string data)
        {
            // I do not like this implementation, but for now it would work
            DateTime CurrentUpdateTime = DateTime.Now;
            _lastUpdateTime = CurrentUpdateTime;
            DelayedExecutionService.DelayedExecute(() =>
            {
                if (CurrentUpdateTime != _lastUpdateTime)
                {
                    return;
                }

                this._checkRelevantDocuments(data).ContinueWith(r =>
                {
                    if (r.Result != null) LastUpdatedResponse = r.Result;
                }
            );


            }, delay: 2);
        }

        private async Task<RelevantDocumentViewModel[]?> _checkRelevantDocuments(string data)
        {
            try
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions.
                HttpResponseMessage response = await client.PostAsync(
                    "https://knowledge.infra.askjusta.com/",
                    content: new StringContent(data)

                );
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                RelevantDocumentViewModel[]? responseData = JsonSerializer.Deserialize<RelevantDocumentViewModel[]>(responseBody);
                return responseData;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Exception happened with api request\nMessage: {0}", ex.Message);
                return null;
            }
        }
    }
}
