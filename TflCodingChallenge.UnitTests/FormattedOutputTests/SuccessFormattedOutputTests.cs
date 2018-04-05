using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using TflCodingChallenge.Output.FormattedOutput;
using TflCodingChallenge.TestHelpers.Mocks;

namespace TflCodingChallenge.UnitTests.FormattedOutputTests
{
    [TestClass]
    public class SuccessFormattedOutputTests
    {
        [TestMethod]
        public void SuccessFormattedOutput_WriteOutput_SuccessMessage()
        {
            // arrange
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                var successFormattedOutput = new SuccessFormattedOutput(stringWriter);
                var currentRoadStatus = new MockCurrentRoadStatus()
                {
                    DisplayName = "A2",
                    StatusSeverity = "Good",
                    StatusSeverityDescription = "No Exceptional Delays"
                };

                // act
                successFormattedOutput.WriteOutput(searchString: "A2", currentRoadStatus: currentRoadStatus);

                // assert
                StringReader stringReader = new StringReader(stringBuilder.ToString());
                var line1 = stringReader.ReadLine();
                Assert.AreEqual(String.Format(SuccessFormattedOutput.SuccessMessageLine1, currentRoadStatus.DisplayName), line1);

                var line2 = stringReader.ReadLine();
                Assert.AreEqual(String.Format(SuccessFormattedOutput.SuccessMessageLine2, currentRoadStatus.StatusSeverity), line2);

                var line3 = stringReader.ReadLine();
                Assert.AreEqual(String.Format(SuccessFormattedOutput.SuccessMessageLine3, currentRoadStatus.StatusSeverityDescription), line3);
            }
        }

        [TestMethod]
        public void SuccessFormattedOutput_WriteOutput_NullRoadCorridor_ArgumentNullException()
        {
            // arrange
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                var successFormattedOutput = new SuccessFormattedOutput(stringWriter);

                // act
                Assert.ThrowsException<ArgumentNullException>(() => successFormattedOutput.WriteOutput("A2", null));
            }
        }

    }
}
