using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using TflCodingChallenge.Output.FormattedOutput;

namespace TflCodingChallenge.UnitTests.FormattedOutputTests
{
    [TestClass]
    public class FailedFormattedOutputTests
    {
        [TestMethod]
        public void FailedFormattedOutput_WriteOutput_WriteFailedMessage()
        {
            // arrange
            const string roadName = "XX";
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                var failedFormatOutput = new FailedFormattedOutput(stringWriter);

                // act
                failedFormatOutput.WriteOutput(searchString: roadName, currentRoadStatus: null);

                // assert
                StringReader stringReader = new StringReader(stringBuilder.ToString());
                var line1 = stringReader.ReadLine();
                Assert.AreEqual(FailedFormattedOutput.FailedMessage, line1);
            }
        }
    }
}
