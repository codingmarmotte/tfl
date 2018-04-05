using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace TflCodingChallenge.TestHelpers
{
    /// <summary>
    /// Helper methods to create HttpResponseMessage classes with different content and/or HttpStatusCodes
    /// </summary>    
    public static class HttpRequestMessageHelper
    {
        public static HttpResponseMessage CreateOKResponse()
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        public static HttpResponseMessage CreateOKResponseWithContent()
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent(File.ReadAllText(@"TestFiles\response.json"));

            httpResponseMessage.Content.Headers.Clear();            
            httpResponseMessage.Content.Headers.Add("Content-Type", "application/json");
            return httpResponseMessage;
        }

        public static HttpResponseMessage CreateOKResponseWithContent<T>(T content) where T:class, new()
        {
            var list = new List<T>();
            list.Add(content);
            var jsonContent = JsonConvert.SerializeObject(list);
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent(jsonContent);
            httpResponseMessage.Content.Headers.Clear();
            httpResponseMessage.Content.Headers.Add("Content-Type", "application/json");
            return httpResponseMessage;
        }

        public static HttpResponseMessage CreateNotFoundResponse()
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public static HttpResponseMessage CreateInvalidResponse()
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        public static HttpResponseMessage CreateNullResponse()
        {
            return null;
        }

    }
}
