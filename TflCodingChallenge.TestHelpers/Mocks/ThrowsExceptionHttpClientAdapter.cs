using System;
using System.Net.Http;
using System.Threading.Tasks;
using TflCodingChallenge.Api;

namespace TflCodingChallenge.TestHelpers.Mocks
{
    /// <summary>
    /// Simulate an exception being thrown by the underlying HttpClient class
    /// </summary>
    public class ThrowsExceptionHttpClientAdapter : IHttpClientAdapter
    {
        public Task<HttpResponseMessage> GetAsync(string request)
        {
            throw new Exception();
        }
    }
}
