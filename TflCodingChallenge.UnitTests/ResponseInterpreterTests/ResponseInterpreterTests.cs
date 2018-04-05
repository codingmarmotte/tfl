using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TflCodingChallenge.Api;
using TflCodingChallenge.TestHelpers;

namespace TflCodingChallenge.UnitTests.ResponseInterpreterTests
{
    [TestClass]
    public class ResponseInterpreterTests
    {
        private ResponseInterpreter<TestResponseData> responseInterpreter;

        [TestInitialize]
        public void TestSetup()
        {
            responseInterpreter = new ResponseInterpreter<TestResponseData>(TestResponseData.ConvertToCurrentRoadStatus);
        }

        [TestMethod]
        public void ResponseInterpreter_Constructor_NullConvertor_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ResponseInterpreter<TestResponseData>(null));
        }

        [TestMethod]
        public async Task ResponseInterpreter_ProcessAsync_OkResponse_SuccessResult()
        {
            // arrange            
            // TestResponseData is a proxy for the data returned from the api
            var content = new TestResponseData
            {
                Property1 = "Test property 1",
                Property2 = "Test property 2",
                Property3 = "Test property 3"
            };

            // Create a response containing a JSON representation of the TestResponseData class
            HttpResponseMessage httpResponseMessage = HttpRequestMessageHelper.CreateOKResponseWithContent(content);

            // act
            var result = await responseInterpreter.ProcessAsync(httpResponseMessage);

            // assert
            Assert.AreEqual(content.Property1, result.DisplayName);
            Assert.AreEqual(content.Property2, result.StatusSeverity);
            Assert.AreEqual(content.Property3, result.StatusSeverityDescription);
        }

        [TestMethod]
        public async Task ResponseInterpreter_ProcessAsync_InvalidContentType_ArgumentException()
        {
            // arrange
            var httpResponseMessage = HttpRequestMessageHelper.CreateOKResponse();
            httpResponseMessage.Content = new StringContent("Test content", System.Text.Encoding.UTF8, "text/plain");

            // act
            // assert            
            await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await responseInterpreter.ProcessAsync(httpResponseMessage));
        }


        [TestMethod]
        public async Task ResponseInterpreter_ProcessAsync_InvalidResponse_ArgumentException()
        {
            // arrange
            var httpResponseMessage = HttpRequestMessageHelper.CreateInvalidResponse();

            // act
            // assert            
            await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await responseInterpreter.ProcessAsync(httpResponseMessage));
        }

        [TestMethod]
        public async Task ResponseInterpreter_ProcessAsync_NullResponse_ArgumentNullException()
        {
            // arrange
            HttpResponseMessage httpResponseMessage = HttpRequestMessageHelper.CreateNullResponse();

            // act
            // assert            
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await responseInterpreter.ProcessAsync(httpResponseMessage));
        }

    }
}
