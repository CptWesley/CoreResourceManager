using CoreResourceManager.Exceptions;
using Xunit;

namespace Librio.Api.Detector.Test.Exceptions
{
    /// <summary>
    /// Test class for the <see cref="ResourceDoesNotExistException"/> class.
    /// </summary>
    public class ResourceDoesNotExistExceptionTests
    {
        /// <summary>
        /// Tests that the message constructor does have the correct message.
        /// </summary>
        [Fact]
        public void MessagedConstructorTest()
        {
            Assert.Equal("bla", new ResourceDoesNotExistException("bla").Message);
        }
    }
}
