namespace TflCodingChallenge.TestHelpers
{
    /// <summary>
    /// This is used as a proxy for the class retrieved from the API for testing
    /// </summary>
    public class TestResponseData
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public string Property3 { get; set; }

        public  static Entities.CurrentRoadStatus ConvertToCurrentRoadStatus(TestResponseData testData)
        {
            return new Entities.CurrentRoadStatus
            {
                DisplayName = testData.Property1,
                StatusSeverity = testData.Property2,
                StatusSeverityDescription = testData.Property3
            };
        }

    }
}
