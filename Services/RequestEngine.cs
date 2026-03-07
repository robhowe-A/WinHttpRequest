//--Copyright (c) 2024-2026 Robert A. Howell

using HttpRequest.Models;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpRequest.Services
{
    internal sealed class RequestEngine
    {
        private bool ShowContentHeaders = false;
        private bool LastFetchReceivedException = false;
        private bool LastFetchIsDnsTestingCandidate = false;
        public Uri? BaseAddress { get; private set; }
        public Exception? LastestException { get; private set; }
        
        private readonly HRFDataExtraction HRFDataExtraction = new();

        public RequestEngine(HRFDataExtraction HRFDataExtraction)
        {
            this.HRFDataExtraction = HRFDataExtraction;
        }

        public async Task<(bool isMessageException, bool isDnsTestingCandidate, string responseData)> CallDataFetch(HRFDataExtraction HRFDataExtraction)
        {
            //Logic redacted for project example
            var res = await DataFetch();
            //Logic redacted for project example
            bool isMessageException = LastFetchReceivedException;
            bool isDnsTestingCandidate = LastFetchIsDnsTestingCandidate;
            return (isMessageException, isDnsTestingCandidate, res);
        }

        public void ToggleShowContentHeaders()
        {
            ShowContentHeaders = ShowContentHeaders ? false : true;
        }

        private async Task<string> DataFetch()
        {
            //Logic redacted for project example

            BaseAddress = HRFDataExtraction.RequestData.BaseAddress;
            string dataFetchDataMessageText = string.Empty;
            LastFetchReceivedException = false;

            HttpClient client = new HttpClient();
            client.BaseAddress = BaseAddress;

            //Logic redacted for project example

            //Add default user agent
            const string userAgent = @"HttpRequestDesktopApp/v1 | HTTP Request application developed by Robert Howell.";
            client.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);

            //Logic redacted for project example

            try
            {
                dataFetchDataMessageText = await SendDataFetch(client);
            }
            catch (Exception e) when (e is InvalidOperationException || e is HttpRequestException || e is TaskCanceledException)
            {
                Debug.Write("\nHttp Request exception caught in fetch!");
                Debug.Write("Message: {0} ", e.Message);
                LastFetchReceivedException = true;
                LastFetchIsDnsTestingCandidate = true;
                LastestException = e;

                return e.Message;
            }
            catch (Exception e)
            {
                Debug.Write("\nException caught in fetch!");
                Debug.Write("Message: {0} ", e.Message);

                return e.Message;
            }

            return dataFetchDataMessageText;
        }

        private async Task<string> SendDataFetch(HttpClient client)
        {
            var Method = HRFDataExtraction.RequestData.Method;
            string responseMessageTextFull = string.Empty;

            if (string.IsNullOrEmpty(HRFDataExtraction.RequestData.Method) || string.Equals(Method, "GET"))
            {
                using HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                var responseMessage = response.EnsureSuccessStatusCode();
                responseMessageTextFull = ShowDataFetchHeaders(responseMessageTextFull, response);
                responseMessageTextFull += await response.Content.ReadAsStringAsync();

            }
            else if (string.Equals(Method, "POST"))
            {
                //Logic redacted for project example
            }
            //Logic redacted for project example
            
            return responseMessageTextFull;
        }

        private string ShowDataFetchHeaders(string responseMessageTextFull, HttpResponseMessage response)
        {
            if (ShowContentHeaders)
            {
                string responseHeaders = HeadersEdit.GetSortedHeadersToString(response.Headers);
                return responseHeaders + "\n";
            }
            else
            {
                return string.Empty;
            }
        }
    };
}
