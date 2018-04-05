using System.Net.Http;
using System.Threading.Tasks;
using TflCodingChallenge.Api;

namespace TflCodingChallenge.TestHelpers.Mocks
{
    /// <summary>
    /// Returns the HttpResponseMessage passed in through the constructor
    /// </summary>
    public class MockHttpClientAdapter : IHttpClientAdapter
    {
        HttpResponseMessage httpResponseMessage;
        public MockHttpClientAdapter(HttpResponseMessage httpResponseMessage)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

        public Task<HttpResponseMessage> GetAsync(string request)
        {
            return Task.FromResult(httpResponseMessage);
        }
    }
}
