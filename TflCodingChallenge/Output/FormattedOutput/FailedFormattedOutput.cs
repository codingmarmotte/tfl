using System.IO;
using TflCodingChallenge.Entities;

namespace TflCodingChallenge.Output.FormattedOutput
{
    public class FailedFormattedOutput : FormattedOutput, IFormattedOutput
    {
        public const string FailedMessage = "Request to the api returned an unexpected response code.";
        public FailedFormattedOutput(TextWriter textWriter)
            : base(textWriter) { }

        public void WriteOutput(string searchString, ICurrentRoadStatus currentRoadStatus)
        {
            textWriter.WriteLine(FailedMessage);
        }
    }
}
