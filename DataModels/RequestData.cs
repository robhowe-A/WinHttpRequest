
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
