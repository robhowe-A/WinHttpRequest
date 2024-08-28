using ArticleJsonFetch.DataModels;
using ArticleJsonFetch.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
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

            //call data fetch method
            HRFDataExtraction.RequestData.ResponseMessage = await DataFetch();

            bool isMessageException = LastFetchReceivedException;
            bool isDnsTestingCandidate = LastFetchIsDnsTestingCandidate;
            string responseData = HRFDataExtraction.RequestData.ResponseMessage;
            return (isMessageException, isDnsTestingCandidate, responseData);
        }

        public void ToggleShowContentHeaders()
        {
            ShowContentHeaders = ShowContentHeaders ? false : true;
        }

        private async Task<string> DataFetch()
        {
            BaseAddress = HRFDataExtraction.RequestData.BaseAddress;
            LastFetchReceivedException = false;
            LastFetchIsDnsTestingCandidate = false;
            string dataFetchDataMessageText = string.Empty;

            //configure http client for fetch
            HttpClient client = new HttpClient();
            client.BaseAddress = BaseAddress;

            try
            {
                dataFetchDataMessageText = await SendDataFetch(client);
            }
            catch (HttpRequestException e) when (e.InnerException?.Message == "No such host is known.")
            {
                Debug.Write("\nHttp Request exception caught in fetch!");
                Debug.Write("Message: {0} ", e.Message);
                LastFetchReceivedException = true;
                LastFetchIsDnsTestingCandidate = true;
                LastestException = e;

                //return string from exception testing(i.e. DNS test)
                return e.Message;
            }
            catch (HttpRequestException e) when (e.InnerException?.Message == "The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch")
            {
                Debug.Write("\nHttp Request exception caught in fetch!");
                Debug.Write("Message: {0} ", e.Message);
                LastFetchReceivedException = true;
                LastestException = e;

                //return string from exception testing(i.e. DNS test)
                return "The SSL connection could not be established. The remote certificate is invalid according to the validation procedure: RemoteCertificateNameMismatch\n";
            }
            catch (HttpRequestException e) when (e.InnerException?.Message == "Authentication failed because the remote party sent a TLS alert: 'HandshakeFailure'.")
            {
                Debug.Write("\nHttp Request exception caught in fetch!");
                Debug.Write("Message: {0} ", e.Message);
                LastFetchReceivedException = true;
                LastestException = e;

                //return string from exception testing(i.e. DNS test)
                return "The SSL connection could not be established. Authentication failed because the remote party sent a TLS alert: 'HandshakeFailure'\n";
            }
            catch (Exception e) when (e is InvalidOperationException || e is HttpRequestException || e is NotSupportedException)
            {
                Debug.Write("\nHttp Request exception caught in fetch!");
                Debug.Write("Message: {0} ", e.Message);
                LastFetchReceivedException = true;
                LastestException = e;

                return e.Message;
            }
            catch (Exception e)
            {
                Debug.Write("\nException caught in fetch!");
                Debug.Write("Message: {0} ", e.Message);
                LastFetchReceivedException = true;

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
            else if (string.Equals(Method, "HEAD"))
            {
                using HttpResponseMessage response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, client.BaseAddress));
                var responseMessage = response.EnsureSuccessStatusCode();

                var responseHeaders = GetSortedHeadersToString(response.Headers);

                responseMessageTextFull = responseHeaders;
            }
            else if (string.Equals(Method, "OPTIONS"))
            {
                using HttpResponseMessage response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Options, client.BaseAddress));
                var responseMessage = response.EnsureSuccessStatusCode();

                var responseHeaders = GetSortedHeadersToString(response.Headers);

                responseMessageTextFull = responseHeaders;
            }
            else if (string.Equals(Method, "POST"))
            {
                using HttpResponseMessage response = await client.PostAsync(client.BaseAddress, HRFDataExtraction.RequestData.MessageBody);
                var responseMessage = response.EnsureSuccessStatusCode();

                responseMessageTextFull = await response.Content.ReadAsStringAsync();
            }
            else if (string.Equals(Method, "PUT"))
            {
                using HttpResponseMessage response = await client.PutAsync(client.BaseAddress, HRFDataExtraction.RequestData.MessageBody);
                var responseMessage = response.EnsureSuccessStatusCode();

                responseMessageTextFull = await response.Content.ReadAsStringAsync();
            }

            return responseMessageTextFull;
        }

        private string ShowDataFetchHeaders(string responseMessageTextFull, HttpResponseMessage response)
        {
            if (ShowContentHeaders)
            {
                string responseHeaders = GetSortedHeadersToString(response.Headers);
                return responseHeaders + "\n";
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetSortedHeadersToString(HttpResponseHeaders Headers)
        {
            // use ToList() function to read response headers
            List<string> responseHeadersList = new List<string>();
            Headers.ToList().ForEach(header =>
                responseHeadersList.Add($"{header.Key}: {string.Join(", ", header.Value)}"));
            // sort the list
            responseHeadersList.Sort();

            // loop through the list and append to StringBuilder
            StringBuilder sb = new StringBuilder();
            foreach (var header in responseHeadersList)
            {
                sb.Append($"{header}\n");
            }
            return sb.ToString();
        }

    }
}
