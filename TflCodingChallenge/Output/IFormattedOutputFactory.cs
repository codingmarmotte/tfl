using TflCodingChallenge.Api;

namespace TflCodingChallenge.Output
{
    public interface IFormattedOutputFactory
    {
        IFormattedOutput GenerateFormattedOutput(ResponseEnum result);
    }
}