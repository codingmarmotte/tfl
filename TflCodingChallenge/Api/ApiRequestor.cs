using System;
using System.Threading.Tasks;
using TflCodingChallenge.Entities;

namespace TflCodingChallenge.Api
{
    public class ApiRequestor<T> : IApiRequestor
    {
        private readonly IHttpClientAdapter httpClient;
        private readonly IResponseInterpreter<T> responseInterpreter;
        public ApiRequestor(IHttpClientAdapter httpClient, IResponseInterpreter<T> responseInterpreter)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.responseInterpreter = responseInterpreter ?? throw new ArgumentNullException(nameof(responseInterpreter));
        }

        public async Task<Tuple<ResponseEnum, CurrentRoadStatus>> GetApiResult(string uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (uri.Length == 0)
            {
                throw new ArgumentException("Uri cannot be empty", nameof(uri));
            }

            // Get the response
            var response = await httpClient.GetAsync(uri);
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return new Tuple<ResponseEnum, CurrentRoadStatus>(ResponseEnum.Success, await responseInterpreter.ProcessAsync(response));
                case System.Net.HttpStatusCode.NotFound:
                    return new Tuple<ResponseEnum, CurrentRoadStatus>(ResponseEnum.NotFound, null);
                default:
                    return new Tuple<ResponseEnum, CurrentRoadStatus>(ResponseEnum.Failed, null);
            }
        }

    }
}
