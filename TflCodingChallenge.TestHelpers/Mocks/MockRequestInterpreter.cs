using System.Net.Http;
using System.Threading.Tasks;
using TflCodingChallenge.Api;
using TflCodingChallenge.Entities;

namespace TflCodingChallenge.TestHelpers.Mocks
{
    public class MockRequestInterpreter<T> : IResponseInterpreter<T>
    {
        readonly CurrentRoadStatus currentRoadStatus;
        public MockRequestInterpreter(CurrentRoadStatus currentRoadStatus)
        {
            this.currentRoadStatus = currentRoadStatus;
        }

        public async Task<CurrentRoadStatus> ProcessAsync(HttpResponseMessage responseMessage)
        {
            return await Task.FromResult(currentRoadStatus);
        }
    }
}
