using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TflCodingChallenge.Output.FormattedOutput;

namespace TflCodingChallenge.UnitTests.FormattedOutputTests
{
    [TestClass]
    public class FormattedOutputTests
    {
        [TestMethod]
        public void FormattedOutput_Constructor_NullTextWriter_ArgumnentNullException()
        {
            // arrange
            // act
            // assert
            Assert.ThrowsException<ArgumentNullException>(() => new FormattedOutput(null));
        }
    }
}

