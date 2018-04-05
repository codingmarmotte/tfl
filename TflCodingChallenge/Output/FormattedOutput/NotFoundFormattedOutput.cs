using System;
using System.IO;
using TflCodingChallenge.Entities;

namespace TflCodingChallenge.Output.FormattedOutput
{
    public class NotFoundFormattedOutput : FormattedOutput, IFormattedOutput
    {
        public const string NotFoundMessage = "{0} is not a valid road";

        public NotFoundFormattedOutput(TextWriter textWriter)
            : base(textWriter) { }

        public void WriteOutput(string searchString, ICurrentRoadStatus currentRoadStatus)
        {
            if (searchString == null)
            {
                throw new ArgumentNullException(nameof(currentRoadStatus));
            }

            if (searchString == String.Empty)
            {
                throw new ArgumentException("Parameter cannot be empty.", nameof(currentRoadStatus));
            }
            textWriter.WriteLine(NotFoundMessage, searchString);
        }
    }
}
