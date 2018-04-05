using System;
using System.Threading.Tasks;
using TflCodingChallenge.Entities;

namespace TflCodingChallenge.Api
{
    public interface IApiRequestor
    {
        Task<Tuple<ResponseEnum, CurrentRoadStatus>> GetApiResult(string uri);
    }
}
