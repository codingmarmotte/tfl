using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tfl.Api.Presentation.Entities;
using TflCodingChallenge.Api;
using TflCodingChallenge.Configuration;
using TflCodingChallenge.Entities;
using TflCodingChallenge.Output;

namespace TflCodingChallenge
{
    class Program
    {
        static HttpClient httpClient = new HttpClient();
        static int Main(string[] args)
        {
            if (args.Length == 0 || args.Length > 1 || String.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("Usage: RoadStatus <roadname> eg RoadStatus A2");
                return (int)ResponseEnum.NotFound;
            }

            try
            {
                var configurationSettings = new ConfigurationSettings();
                return runAsync(args[0], configurationSettings).Result;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unexpected exception occured.");
                Console.WriteLine("Exception detail:");
                Console.Write(exception);
                return (int)ResponseEnum.ExceptionOccured;
            }
        }

        static async Task<int> runAsync(string roadName, IConfigurationSettings configuration)
        {
            httpClient.BaseAddress = configuration.BaseUri;
            var httpClientAdapter = new HttpClientAdapter(httpClient);

            // Construct the api Uri to pass 
            var uri = $"/road/{roadName}?app_id={configuration.AppId}&app_key={configuration.AppKey}";

            IResponseInterpreter<RoadCorridor> responseInterpreter = new ResponseInterpreter<RoadCorridor>(r => new CurrentRoadStatus
            {
                DisplayName = r.DisplayName,
                StatusSeverity = r.StatusSeverity,
                StatusSeverityDescription = r.StatusSeverityDescription
            });

            // Construct the api requestor passing in the httpClient and the class that interprets the response
            var apiRequestor = new ApiRequestor<RoadCorridor>(httpClientAdapter, responseInterpreter);

            // Make the request and format the response into the CurrentRoadStatus entity
            var interpretedResponse = await apiRequestor.GetApiResult(uri);

            // Deconstruct the response tuple
            var responseCode = interpretedResponse.Item1;
            var currentRoadStatus = interpretedResponse.Item2;

            // Write out the appropriate message
            FormattedOutputFactory formattedOutputFactory = new FormattedOutputFactory(Console.Out);
            var formattedOutput = formattedOutputFactory.GenerateFormattedOutput(responseCode);
            formattedOutput.WriteOutput(roadName, currentRoadStatus);

            // Return an integer result to return back to the console
            return (int)responseCode;
        }
    }
}
