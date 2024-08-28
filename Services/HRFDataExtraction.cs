using ArticleJsonFetch.DataModels;
using ArticleJsonFetch.Models;
using System;
using System.Net.Http;
using System.Text;


namespace ArticleJsonFetch.Services
{
    public class HRFDataExtraction
    {
        public RequestData RequestData { get => _requestData; }
        private readonly RequestData _requestData = new ();

        public void SetRequestBaseAddress(string baseUrl)
        {
            _requestData.BaseAddress = new Uri(baseUrl);
        }

        public void SetRequestBody(string requestBodyText)
        {
            if (String.IsNullOrEmpty(requestBodyText))
            {
                RequestData.MessageBody = new StringContent(@"{{ ""HttpRequestFormError"":""The request body message is missing.""}}");
            }
            _requestData.MessageBody = new StringContent(requestBodyText);
        }

        public void SetRequestMethod(string requestMethod)
        {
            _requestData.Method = requestMethod;
        }

        public void SetRequestMessageBody(string messageBodyText, string contentType)
        {
            if (String.IsNullOrWhiteSpace(contentType))
            {
                if (_requestData.MessageBody != null && _requestData.MessageBody.Headers.Contains("Content-Type"))
                    _requestData.MessageBody.Headers.Remove("Content-Type");
                _requestData.MessageBody = new StringContent(messageBodyText);
            }
            else if (String.Equals(contentType, "application/json"))
            {
                _requestData.ContentType = contentType;
                _requestData.MessageBody = new StringContent(messageBodyText);

                //_requestData.MessageBody = new StringContent(messageBodyText, Encoding.UTF8, "application/json");
                _requestData.MessageBody.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            }
            else
            {
                _requestData.MessageBody = new StringContent(messageBodyText);
            }
        }
    }
}
