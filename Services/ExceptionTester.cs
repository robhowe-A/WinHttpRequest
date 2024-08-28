using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                Debug.Write($"Tried Dns test. Failed! Check the stack trace. Stack trace: \n{ex.StackTrace}");
                dnsTestResult += $"\n{DateTime.UtcNow.ToLongTimeString()} - Dns test failed. ";
                dnsTestResult += $"\n{DateTime.UtcNow.ToLongTimeString()} - Name resolution failed for {baseAddress.Host}:{baseAddress.Port}";
                dnsTestResult += $"\n{DateTime.UtcNow.ToLongTimeString()} - {ex.Message}";
                dnsTestResult += $"\n{DateTime.UtcNow.ToLongTimeString()} - Check the network connection or try again using a different host.\n";
            }
            return dnsTestResult;
        }

        private static string PingTest(IPAddress host)
        {
            string pingTestResult = string.Empty;
            try
            {
                Ping myPing = new Ping();
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                pingTestResult += $"\nPing success...\nReply from took {reply.RoundtripTime} milliseconds:\n\tHost: {host}\n\tAddress: {reply.Address}\n\tRTT: {reply.RoundtripTime}\n\tTimeout: {timeout}\n";
                pingTestResult += $"\nSend another Ping to {host}? (Ping(P)/Cancel(C))\n";
            }
            catch (PingException ex)
            {
                if (string.Equals(ex.Source, "System.Net.Ping"))
                    pingTestResult += $"\nPlease check your network connection.\nAn exception occurred attempting to ping host: {host}. \n{ex.InnerException!.StackTrace}\n{ex.StackTrace}\n";
                else
                    pingTestResult += $"\nAn exception occurred attempting to ping host: {host}. \n{ex.InnerException!.StackTrace}\n{ex.StackTrace}\n";
            }
            catch (Exception ex)
            {
                Debug.Write($"Tried Ping. Failed! Check the stack trace. Stack trace: \n{ex.InnerException!.StackTrace}");
                pingTestResult += $"\nAn exception occurred at: \n{ex.InnerException.StackTrace}";
            }
            return pingTestResult;
        }

    }
}
