using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EzarisHomeWeb.Helpers
{
    public static class RequestHelper
    {
        public static async Task<string> GetRequest(string requestUrl)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var httpClient = new HttpClient(clientHandler);
            var response = await httpClient.GetStringAsync(requestUrl);

            return response;
        }

        public static async Task<HttpContent> PostRequest(string requestUrl, string payload)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            var stringContent = new StringContent(payload, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+


            var httpClient = new HttpClient(clientHandler);
            var response = await httpClient.PostAsync(requestUrl, stringContent);

            return response.Content;
        }
    }
}
