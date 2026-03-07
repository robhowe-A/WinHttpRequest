//--Copyright (c) 2024-2026 Robert A. Howell

using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;

namespace HttpRequest.Models
{
    internal static class HeadersEdit
    {
        public static string GetSortedHeadersToString(HttpResponseHeaders Headers)
        {
            // Create a new list object
            List<string> responseHeadersList = new List<string>();

            // Use ToList() function to add each header to a new list
            Headers.ToList().ForEach(header =>
                responseHeadersList.Add($"{header.Key}: {string.Join(", ", header.Value)}"));

            // Sort the list
            responseHeadersList.Sort();

            // Create a stringbuilder for the return string
            StringBuilder sb = new StringBuilder();

            // Loop through the list and append to StringBuilder
            foreach (var header in responseHeadersList)
            {
                sb.Append($"{header}\n");
            }

            return sb.ToString();
        }
    };
}
