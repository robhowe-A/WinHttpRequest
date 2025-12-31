//--Copyright (c) 2024-2026 Robert A. Howell

namespace HttpRequest.DataModels
{
    internal class RequestData
    {
        public System.Uri? BaseAddress { get; set; }
        public string Method { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public System.Net.Http.StringContent? MessageBody { get; set; }
        public string ResponseMessage { get; set; } = string.Empty;
    };
}
