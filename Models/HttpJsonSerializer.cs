//--Copyright (c) 2024-2026 Robert A. Howell

using System;

namespace HttpRequest.Models
{
    internal class HttpJsonSerializer
    {
        public Object obj = new();
        public bool isJson = false;

        public HttpJsonSerializer()
        {
        }

        public void DeserializeToJson(ref string str)
        {
            //Logic redacted for project example
        }
    };
}
