using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TflCodingChallenge.Api;

namespace TflCodingChallenge.UnitTests.HttpClientAdapterTests
{
    [TestClass]
    public class HttpClientAdapterTests
    {
        [TestMethod]
        public void HttpClientAdapter_Constructor_HttpClientIsNull_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new HttpClientAdapter(null));
        }
    }
}
