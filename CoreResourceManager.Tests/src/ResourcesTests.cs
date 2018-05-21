using System.IO;
using CoreResourceManager.Exceptions;
using Xunit;

namespace CoreResourceManager.Tests
{
    /// <summary>
    /// Test class for the <see cref="Resources"/> class.
    /// </summary>
    public static class ResourcesTests
    {
        /// <summary>
        /// Checks that the resource is retrieved correctly.
        /// </summary>
        [Fact]
        public static void GetStreamTest()
        {
            Stream stream = Resources.Get("demo.txt");
            StreamReader reader = new StreamReader(stream);
            Assert.Equal("hello world", reader.ReadToEnd());
        }

        /// <summary>
        /// Checks that the resource is retrieved correctly.
        /// </summary>
        [Fact]
        public static void InvalidResourceTest()
        {
            Assert.Throws<ResourceDoesNotExistException>(() => Resources.Get("2fw464"));
        }

        /// <summary>
        /// Checks that the names of the resources get returned correctly.
        /// </summary>
        [Fact]
        public static void GetNamesTest()
        {
            Assert.Single(Resources.GetNames());
            Assert.Contains("demo.txt", Resources.GetNames());
        }
    }
}
