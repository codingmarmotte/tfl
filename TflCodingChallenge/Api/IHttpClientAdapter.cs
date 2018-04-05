using System.Net.Http;
using System.Threading.Tasks;

namespace TflCodingChallenge.Api
{
    public interface IHttpClientAdapter
    {
        Task<HttpResponseMessage> GetAsync(string request);
    }
}
