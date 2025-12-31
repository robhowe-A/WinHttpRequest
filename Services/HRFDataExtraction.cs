//--Copyright (c) 2024-2026 Robert A. Howell

using System;
using HttpRequest.DataModels;

namespace HttpRequest.Services
{
    internal class HRFDataExtraction
    {
        public RequestData RequestData => _requestData;
        private readonly RequestData _requestData = new ();

        public void SetRequestBaseAddress(string baseUrl)
        {
            _requestData.BaseAddress = new Uri(baseUrl);
        }

        public void SetRequestBody(string requestBodyText)
        {
            //Logic redacted for project example
        }

        public void SetRequestMethod(string requestMethod)
        {
            //Logic redacted for project example
        }

        public void SetRequestMessageBody(string messageBodyText, string contentType)
        {
            //Logic redacted for project example
        }
    };
}
