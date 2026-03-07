//--Copyright (c) 2024-2026 Robert A. Howell

using System;
using System.Diagnostics;
using System.Net;

namespace HttpRequest.Services
{
    internal static class ExceptionTester
    {
        public static string DnsTest(Uri baseAddress)
        {
            string dnsTestResult = string.Empty;
            try
            {
                var hostInfo = Dns.GetHostEntry(baseAddress.Host);
                dnsTestResult += $"\nDns test successful...\nFound {hostInfo.AddressList.Length} addresses:\n\tAddresses: ";
                foreach (var addr in hostInfo.AddressList)
                {
                    dnsTestResult += $"\n\t{addr.ToString()}";
                }

                dnsTestResult += $"\nSend another test to {baseAddress.Host} ( Test (Alt + T)/Cancel (Alt + N) )?\n";

                return dnsTestResult;
            }
            catch (Exception ex)
            {
                Debug.Write($"Tried Dns test. Failed! Check the stack trace.\n{ex.StackTrace}");
                dnsTestResult += $"\n{DateTime.UtcNow.ToLongTimeString()} - Dns test failed. ";
                dnsTestResult += $"\n{DateTime.UtcNow.ToLongTimeString()} - Name resolution failed for {baseAddress.Host}:{baseAddress.Port}";
                dnsTestResult += $"\n{DateTime.UtcNow.ToLongTimeString()} - {ex.Message}";
                dnsTestResult += $"\n{DateTime.UtcNow.ToLongTimeString()} - Check the network connection or try again using a different host.\n";
            }
            return dnsTestResult;
        }
    };
}
