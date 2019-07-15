using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ApiConsumerApp
{
    public static class HttpClientVariable
    {
        public static HttpClient ApiClient = new HttpClient();

        static HttpClientVariable()
        {
            ApiClient.BaseAddress = new Uri("http://localhost:60995/api/");
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}