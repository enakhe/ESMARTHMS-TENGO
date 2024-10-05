using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace ESMART_HMS.Domain.Utils
{
    public class EmailHelper
    {
        private static readonly string apiBaseUri = "https://api.mailgun.net/v3";
        private static readonly string domainName = "eitiltech.com";
        private static readonly string apiKey = "141f8c86e514744f13b7b3961a3d6817-1b5736a5-c57aa27e";

        public static async Task<string> SendEmail(string to, string subject, string body)
        {
            using (HttpClient client = new HttpClient())
            {
                var byteArray = Encoding.ASCII.GetBytes($"api:{apiKey}");
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("from", "noreply@eitiltech.com"),
                    new KeyValuePair<string, string>("to", to),
                    new KeyValuePair<string, string>("subject", subject),
                    new KeyValuePair<string, string>("text", body)
                });

                HttpResponseMessage response = await client.PostAsync($"{apiBaseUri}/{domainName}/messages", content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
