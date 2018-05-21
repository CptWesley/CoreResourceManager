using System;
using CoreResourceManager.Exceptions;
using Moq;
using Xunit;

namespace Librio.Api.Detector.Test.Exceptions
{
    /// <summary>
    /// Test class for the <see cref="ResourceDoesNotExistException"/> class.
    /// </summary>
    public static class ResourceDoesNotExistExceptionTests
    {
        /// <summary>
        /// Tests that the message constructor does have the correct message.
        /// </summary>
        [Fact]
        public static void MessagedConstructorTest()
        {
            Assert.Equal("bla", new ResourceDoesNotExistException("bla").Message);
        }

        /// <summary>
        /// Tests that the inner exception constructor does have the correct inner exception.
        /// </summary>
        [Fact]
        public static void InnerExceptionConstructorTest()
        {
            Exception e = new Mock<Exception>().Object;
            Assert.Same(e, new ResourceDoesNotExistException(string.Empty, e).InnerException);
        }

        /// <summary>
        /// Checks that the exception is throwable.
        /// </summary>
        [Fact]
        public static void NormalThrownTest()
        {
            Assert.ThrowsAsync<ResourceDoesNotExistException>(() => throw new ResourceDoesNotExistException());
        }

        /// <summary>
        /// Checks that the exception is throwable.
        /// </summary>
        [Fact]
        public static void MessageThrownTest()
        {
            Assert.ThrowsAsync<ResourceDoesNotExistException>(() => throw new ResourceDoesNotExistException(string.Empty));
        }

        /// <summary>
        /// Checks that the exception is throwable.
        /// </summary>
        [Fact]
        public static void InnerThrownTest()
        {
            Assert.ThrowsAsync<ResourceDoesNotExistException>(() => throw new ResourceDoesNotExistException(string.Empty, null));
        }
    }
}
