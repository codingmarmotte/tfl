using TflCodingChallenge.Entities;

namespace TflCodingChallenge.Output
{
    public interface IFormattedOutput
    {
        void WriteOutput(string searchString, ICurrentRoadStatus currentRoadStatus);
    }
}
