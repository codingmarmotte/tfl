using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TflCodingChallenge.Api;
using TflCodingChallenge.TestHelpers;
using TflCodingChallenge.TestHelpers.Mocks;

namespace TflCodingChallenge.UnitTests.ApiRequestorTests
{
    /// <summary>
    /// Summary description for ApiRequestorTest
    /// </summary>
    [TestClass]
    public class ApiRequestorTests
    {
        private const string testUri = "/road/a2";

        private IResponseInterpreter<TestResponseData> responseInterpreter = new MockRequestInterpreter<TestResponseData>(new Entities.CurrentRoadStatus { DisplayName = "A2", StatusSeverity = "Good", StatusSeverityDescription = "Good" });
        [TestMethod]
        public void ApiRequestor_Constructor_ISimpleHttpClientIsNull_ArgumentNullException()
        {
            // arrange
            IHttpClientAdapter httpClient = null;

            // act
            // assert
            Assert.ThrowsException<ArgumentNullException>(() => new ApiRequestor<TestResponseData>(httpClient, responseInterpreter));
        }

        [TestMethod]
        public void ApiRequestor_Constructor_IResponseInterpreterIsNull_ArgumentNullException()
        {
            // arrange
            var httpClient = new MockHttpClientAdapter(null);

            // act
            // assert
            Assert.ThrowsException<ArgumentNullException>(() => new ApiRequestor<TestResponseData>(httpClient, null));
        }

        [TestMethod]
        public async Task ApiRequestor_GetApiResult_EmptyStringUri_ArgumentException()
        {
            // arrange
            var httpClient = new MockHttpClientAdapter(null);
            var apiRequestor = new ApiRequestor<TestResponseData>(httpClient, responseInterpreter);

            // act 
            // assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await apiRequestor.GetApiResult(String.Empty));
        }

        [TestMethod]
        public async Task ApiRequestor_GetApiResult_NullUri_ArgumentNullException()
        {
            // arrange
            var httpClient = new MockHttpClientAdapter(null);
            var apiRequestor = new ApiRequestor<TestResponseData>(httpClient, responseInterpreter);

            // act 
            // assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await apiRequestor.GetApiResult(null));
        }

        [TestMethod]
        public async Task ApiRequestor_GetApiResult_NotFoundHttpResponse_NotFoundResult_()
        {
            // arrange
            var httpClient = new MockHttpClientAdapter(HttpRequestMessageHelper.CreateNotFoundResponse());
            var apiRequestor = new ApiRequestor<TestResponseData>(httpClient, responseInterpreter);

            // act 
            var result = await apiRequestor.GetApiResult(testUri);

            // assert
            Assert.AreEqual(result.Item1, ResponseEnum.NotFound);
            Assert.IsNull(result.Item2);
        }

        [TestMethod]
        public async Task ApiRequestor_GetApiResult_OtherHttpResponse_FailedResult()
        {
            // arrange
            var httpClient = new MockHttpClientAdapter(HttpRequestMessageHelper.CreateInvalidResponse());
            var apiRequestor = new ApiRequestor<TestResponseData>(httpClient, responseInterpreter);

            // act 
            var result = await apiRequestor.GetApiResult(testUri);

            // assert
            Assert.AreEqual(result.Item1, ResponseEnum.Failed);
            Assert.IsNull(result.Item2);
        }

        [TestMethod]
        public async Task ApiRequestor_GetApiResult_OkHttpResponse_SuccessResult()
        {
            // arrange            
            var currentRoadStatus = new Entities.CurrentRoadStatus { DisplayName = "A2", StatusSeverity = "Good", StatusSeverityDescription = "Good" };
            var responseInterpreter = new MockRequestInterpreter<TestResponseData>(currentRoadStatus);
            var httpClient = new MockHttpClientAdapter(HttpRequestMessageHelper.CreateOKResponse());
            var apiRequestor = new ApiRequestor<TestResponseData>(httpClient, responseInterpreter);

            // act 
            var result = await apiRequestor.GetApiResult(testUri);

            // assert
            Assert.AreEqual(result.Item1, ResponseEnum.Success);
            Assert.AreEqual(currentRoadStatus.DisplayName, result.Item2.DisplayName);
            Assert.AreEqual(currentRoadStatus.StatusSeverity, result.Item2.StatusSeverity);
            Assert.AreEqual(currentRoadStatus.StatusSeverityDescription, result.Item2.StatusSeverityDescription);
        }
    }
}
