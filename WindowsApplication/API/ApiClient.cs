﻿using System;
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
    // TODO the http client is too coupled with the interface.
    public class ApiClient : ObservableObject
    {
        private RelevantDocumentData[]? _lastResponse = null;
        public RelevantDocumentData[]? LastUpdatedResponse
        {
            get => _lastResponse;
            private set {
                if (_lastResponse == value) return;
                _lastResponse = value;
                onPropertyChanged("LastUpdatedResponse");
            }
        }
        private DateTime _lastUpdateTime;
        
        static readonly HttpClient client = new HttpClient();

        public void Update(string data)
        {
            DateTime CurrentUpdateTime = DateTime.Now;
            this._checkRelevantDocuments(data).ContinueWith(r =>
            {
                if (r != null && _lastUpdateTime < CurrentUpdateTime)
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
                    "https://infra.askjusta.com/knowledge/",
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
