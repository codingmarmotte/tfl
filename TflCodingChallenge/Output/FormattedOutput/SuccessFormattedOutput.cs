using System;
using System.IO;
using TflCodingChallenge.Entities;

namespace TflCodingChallenge.Output.FormattedOutput
{
    public class SuccessFormattedOutput : FormattedOutput, IFormattedOutput
    {
        public const string SuccessMessageLine1 = "The status of the {0} is as follows";
        public const string SuccessMessageLine2 = "\tRoad status is {0}";
        public const string SuccessMessageLine3 = "\tRoad status description is {0}";

        public SuccessFormattedOutput(TextWriter textWriter)
            : base(textWriter) { }

        public void WriteOutput(string searchString, ICurrentRoadStatus currentRoadStatus)
        {
            if (currentRoadStatus == null)
            {
                throw new ArgumentNullException(nameof(currentRoadStatus));
            }

            textWriter.WriteLine(SuccessMessageLine1, currentRoadStatus.DisplayName);
            textWriter.WriteLine(SuccessMessageLine2, currentRoadStatus.StatusSeverity);
            textWriter.WriteLine(SuccessMessageLine3, currentRoadStatus.StatusSeverityDescription);
        }
    }
}
