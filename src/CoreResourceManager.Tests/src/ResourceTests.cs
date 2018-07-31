using System.IO;
using CoreResourceManager.Exceptions;
using Xunit;

namespace CoreResourceManager.Tests
{
    /// <summary>
    /// Test class for the <see cref="Resource"/> class.
    /// </summary>
    public static class ResourceTests
    {
        /// <summary>
        /// Checks that the resource is retrieved correctly.
        /// </summary>
        [Fact]
        public static void GetStreamTest()
        {
            Stream stream = Resource.Get("demo.txt");
            StreamReader reader = new StreamReader(stream);
            Assert.Equal("hello world", reader.ReadToEnd());
        }

        /// <summary>
        /// Checks that the resource is retrieved correctly.
        /// </summary>
        [Fact]
        public static void InvalidResourceTest()
        {
            Assert.Throws<ResourceDoesNotExistException>(() => Resource.Get("2fw464"));
        }

        /// <summary>
        /// Checks that the names of the resources get returned correctly.
        /// </summary>
        [Fact]
        public static void GetNamesTest()
        {
            string[] res = Resource.GetNames();
            Assert.Equal(3, res.Length);
            Assert.Contains("demo.txt", res);
            Assert.Contains("Sub.demo1.txt", res);
            Assert.Contains("Sub.demo2.txt", res);
        }

        /// <summary>
        /// Checks that sub folder items are found correctly.
        /// </summary>
        [Fact]
        public static void GetNamesSubTest()
        {
            string[] res = Resource.GetNames("Sub");
            Assert.Equal(2, res.Length);
            Assert.DoesNotContain("demo.txt", res);
            Assert.Contains("Sub.demo1.txt", res);
            Assert.Contains("Sub.demo2.txt", res);
        }

        /// <summary>
        /// Checks if the paths are correctly trimmed.
        /// </summary>
        [Fact]
        public static void TrimTest()
        {
            string[] res = Resource.GetNames(".Sub.");
            Assert.Equal(2, res.Length);
        }

        /// <summary>
        /// Checks if the paths with forward slashes are correctly found.
        /// </summary>
        [Fact]
        public static void ForwardSlashTest()
        {
            string[] res = Resource.GetNames("/Sub");
            Assert.Equal(2, res.Length);
        }

        /// <summary>
        /// Checks if the paths with backward slashes are correctly found.
        /// </summary>
        [Fact]
        public static void BackwardSlashTest()
        {
            string[] res = Resource.GetNames("\\Sub");
            Assert.Equal(2, res.Length);
        }
    }
}
