using TflCodingChallenge.Entities;

namespace TflCodingChallenge.TestHelpers.Mocks
{
    public class MockCurrentRoadStatus : ICurrentRoadStatus
    {
        public string DisplayName { get; set; }

        public string StatusSeverity { get; set; }

        public string StatusSeverityDescription { get; set; }
    }
}
