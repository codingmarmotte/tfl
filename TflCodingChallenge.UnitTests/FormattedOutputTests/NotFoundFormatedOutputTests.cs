using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using TflCodingChallenge.Output.FormattedOutput;

namespace TflCodingChallenge.UnitTests.FormattedOutputTests
{
    [TestClass]
    public class NotFoundFormatedOutputTests
    {
        [TestMethod]
        public void NotFoundFormattedOutput_WriteOutput_WriteNotFoundMessage()
        {
            // arrange
            const string roadName = "XX";
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                var notFoundFormattedOutput = new NotFoundFormattedOutput(stringWriter);

                // act
                notFoundFormattedOutput.WriteOutput(searchString: roadName, currentRoadStatus: null);

                // assert
                StringReader stringReader = new StringReader(stringBuilder.ToString());
                var line1 = stringReader.ReadLine();
                Assert.AreEqual(String.Format(NotFoundFormattedOutput.NotFoundMessage, roadName), line1);
            }
        }

        [TestMethod]
        public void NotFoundFormattedOutput_WriteOutput_NullSearchString_ArgumentNullException()
        {
            // arrange
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                var notFoundFormattedOutput = new NotFoundFormattedOutput(stringWriter);

                // act
                // assert
                Assert.ThrowsException<ArgumentNullException>(() => notFoundFormattedOutput.WriteOutput(searchString: null, currentRoadStatus: null));
            }
        }

        [TestMethod]
        public void NotFoundFormattedOutput_WriteOutput_EmptySearchString_ArgumentException()
        {
            // arrange
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                var notFoundFormattedOutput = new NotFoundFormattedOutput(stringWriter);

                // act
                // assert
                Assert.ThrowsException<ArgumentException>
                    (() => notFoundFormattedOutput.WriteOutput(searchString: String.Empty, currentRoadStatus: null));
            }
        }
    }
}
