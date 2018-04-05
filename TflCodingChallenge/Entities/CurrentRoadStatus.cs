namespace TflCodingChallenge.Entities
{
    public class CurrentRoadStatus : ICurrentRoadStatus
    {
        public string DisplayName { get; set; }

        public string StatusSeverity { get; set; }

        public string StatusSeverityDescription { get; set; }
    }
}
