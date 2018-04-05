using System;

namespace TflCodingChallenge.Entities
{
    public interface ICurrentRoadStatus
    {
        String DisplayName { get; }
        String StatusSeverity { get; }
        String StatusSeverityDescription { get; }
    }
}
