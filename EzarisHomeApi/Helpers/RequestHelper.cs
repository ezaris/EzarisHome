using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EzarisHomeApi.Helpers {
    public static class RequestHelper {
        public static Task<string> CallGet(string url)
        {
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(url);
            return response;
        }
        public static Task<HttpResponseMessage> CallPost(string url, StringContent payload)
        {
            HttpClient client = new HttpClient();
            var response = client.PostAsync(url, payload);
            return response;
        }
    }
}
