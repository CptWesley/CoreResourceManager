using System;
using CoreResourceManager.Exceptions;
using Moq;
using Xunit;

using static AssertNet.Xunit.Assertions;

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
            AssertThat(new ResourceDoesNotExistException("bla")).WithMessage("bla");
        }

        /// <summary>
        /// Tests that the inner exception constructor does have the correct inner exception.
        /// </summary>
        [Fact]
        public static void InnerExceptionConstructorTest()
        {
            Exception e = new Mock<Exception>().Object;
            AssertThat(new ResourceDoesNotExistException(string.Empty, e).InnerException).IsSameAs(e);
        }

        /// <summary>
        /// Checks that the exception is throwable.
        /// </summary>
        [Fact]
        public static void NormalThrownTest()
        {
            AssertThat(() => throw new ResourceDoesNotExistException()).ThrowsExactlyException<ResourceDoesNotExistException>();
        }

        /// <summary>
        /// Checks that the exception is throwable.
        /// </summary>
        [Fact]
        public static void MessageThrownTest()
        {
            AssertThat(() => throw new ResourceDoesNotExistException(string.Empty)).ThrowsExactlyException<ResourceDoesNotExistException>();
        }

        /// <summary>
        /// Checks that the exception is throwable.
        /// </summary>
        [Fact]
        public static void InnerThrownTest()
        {
            AssertThat(() => throw new ResourceDoesNotExistException(string.Empty, null)).ThrowsExactlyException<ResourceDoesNotExistException>();
        }
    }
}
