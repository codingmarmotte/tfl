using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TflCodingChallenge.Api
{
    public class HttpClientAdapter : IHttpClientAdapter
    {
        private readonly HttpClient httpClient;
        public HttpClientAdapter(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public Task<HttpResponseMessage> GetAsync(string request)
        {
            return httpClient.GetAsync(request);
        }
    }
}
