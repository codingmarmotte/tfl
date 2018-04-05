using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TflCodingChallenge.Entities;

namespace TflCodingChallenge.Api
{
    public class ResponseInterpreter<T> : IResponseInterpreter<T>
    {
        Func<T, CurrentRoadStatus> convertor;
        public ResponseInterpreter(Func<T, CurrentRoadStatus> convertor)
        {
            this.convertor = convertor ?? throw new ArgumentNullException(nameof(convertor));
        }

        public async Task<CurrentRoadStatus> ProcessAsync(HttpResponseMessage responseMessage)
        {
            if (responseMessage == null)
            {
                throw new ArgumentNullException(nameof(responseMessage));
            }

            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new ArgumentException("Status code must be HttpStatusCode.OK", nameof(responseMessage));
            }

            if (responseMessage.Content.Headers.ContentType.MediaType != "application/json")
            {
                throw new ArgumentException("Content type must be application/json", nameof(responseMessage));
            }

            // Parse the response into type of T as passed in 
            var jsonContent = await responseMessage.Content.ReadAsAsync<IEnumerable<T>>();

            // Select the first result from the api response as it returns an array
            var parsedResponseObject = jsonContent.First();

            // Convert T to a CurrentRoadStatus type and return
            return convertor(parsedResponseObject);

        }
    }
}
