using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tfl.Api.Presentation.Entities;
using TflCodingChallenge.Api;
using TflCodingChallenge.Entities;
using TflCodingChallenge.Output;
using TflCodingChallenge.Output.FormattedOutput;
using TflCodingChallenge.TestHelpers;
using TflCodingChallenge.TestHelpers.Mocks;

namespace TflCodingChallenge.IntegrationTests
{
    [TestClass]
    public class IntegrationTests
    {
        /// <summary>
        /// End to end test using a local json file as the response from MockHttpClientAdapter
        /// and writing the formatted response to a StringBuilder
        /// </summary>
        [TestMethod]
        public async Task IntegrationTest_ValidRequest()
        {
            const string roadName = "a2";
            const string apiPath = "/road/a2";

            // arrange
            var response = HttpRequestMessageHelper.CreateOKResponseWithContent();
            var httpClientAdapter = new MockHttpClientAdapter(response);

            IResponseInterpreter<RoadCorridor> responseInterpreter =
                new ResponseInterpreter<RoadCorridor>(r => new CurrentRoadStatus
                {
                    DisplayName = r.DisplayName,
                    StatusSeverity = r.StatusSeverity,
                    StatusSeverityDescription = r.StatusSeverityDescription
                });
            IApiRequestor apiRequestor = new ApiRequestor<RoadCorridor>(httpClientAdapter, responseInterpreter);

            //act            
            var interpretedResponse = await apiRequestor.GetApiResult(apiPath);

            // Deconstruct the tuple
            var responseCode = interpretedResponse.Item1;
            var currentRoadStatus = interpretedResponse.Item2;

            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                FormattedOutputFactory formattedOutputFactory = new FormattedOutputFactory(stringWriter);
                var formattedOutput = formattedOutputFactory.GenerateFormattedOutput(responseCode);
                formattedOutput.WriteOutput(roadName, currentRoadStatus);
            }

            // assert
            StringReader stringReader = new StringReader(stringBuilder.ToString());
            var line1 = stringReader.ReadLine();
            Assert.AreEqual(String.Format(SuccessFormattedOutput.SuccessMessageLine1, currentRoadStatus.DisplayName), line1);

            var line2 = stringReader.ReadLine();
            Assert.AreEqual(String.Format(SuccessFormattedOutput.SuccessMessageLine2, currentRoadStatus.StatusSeverity), line2);

            var line3 = stringReader.ReadLine();
            Assert.AreEqual(String.Format(SuccessFormattedOutput.SuccessMessageLine3, currentRoadStatus.StatusSeverityDescription), line3);
        }

        [TestMethod]
        public async Task IntegrationTest_NotFoundRequest()
        {
            const string roadName = "xx";
            const string apiPath = "/road/xx";

            // arrange
            var response = HttpRequestMessageHelper.CreateNotFoundResponse();
            var httpClientAdapter = new MockHttpClientAdapter(response);

            IResponseInterpreter<RoadCorridor> responseInterpreter = new ResponseInterpreter<RoadCorridor>(r => new CurrentRoadStatus
            {
                DisplayName = r.DisplayName,
                StatusSeverity = r.StatusSeverity,
                StatusSeverityDescription = r.StatusSeverityDescription
            });
            IApiRequestor apiRequestor = new ApiRequestor<RoadCorridor>(httpClientAdapter, responseInterpreter);

            //act            
            var interpretedResponse = await apiRequestor.GetApiResult(apiPath);

            // Deconstruct the tuple
            var responseCode = interpretedResponse.Item1;
            var currentRoadStatus = interpretedResponse.Item2;

            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                FormattedOutputFactory formattedOutputFactory = new FormattedOutputFactory(stringWriter);
                var formattedOutput = formattedOutputFactory.GenerateFormattedOutput(responseCode);
                formattedOutput.WriteOutput(roadName, currentRoadStatus);
            }

            // assert
            StringReader stringReader = new StringReader(stringBuilder.ToString());
            var line1 = stringReader.ReadLine();
            Assert.AreEqual(String.Format(NotFoundFormattedOutput.NotFoundMessage, roadName), line1);
        }

    }
}
