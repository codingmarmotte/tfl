using System.Net.Http;
using System.Threading.Tasks;
using TflCodingChallenge.Entities;

namespace TflCodingChallenge.Api
{
    public interface IResponseInterpreter<T>
    {
        Task<CurrentRoadStatus> ProcessAsync(HttpResponseMessage responseMessage);
    }
}
