using System.IO;
using CoreResourceManager.Exceptions;
using Xunit;

using static AssertNet.Xunit.Assertions;

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
            AssertThat(reader.ReadToEnd()).IsEqualTo("hello world");
        }

        /// <summary>
        /// Checks that the resource is retrieved correctly.
        /// </summary>
        [Fact]
        public static void InvalidResourceTest()
        {
            AssertThat(() => Resource.Get("2fw464")).ThrowsExactlyException<ResourceDoesNotExistException>();
        }

        /// <summary>
        /// Checks that the names of the resources get returned correctly.
        /// </summary>
        [Fact]
        public static void GetNamesTest()
        {
            string[] res = Resource.GetNames();
            AssertThat(res).HasSize(3);
            AssertThat(res).Contains("demo.txt");
            AssertThat(res).Contains("Sub.demo1.txt");
            AssertThat(res).Contains("Sub.demo2.txt");
        }

        /// <summary>
        /// Checks that sub folder items are found correctly.
        /// </summary>
        [Fact]
        public static void GetNamesSubTest()
        {
            string[] res = Resource.GetNames("Sub");
            AssertThat(res).HasSize(2);
            AssertThat(res).DoesNotContain("demo.txt");
            AssertThat(res).Contains("Sub.demo1.txt");
            AssertThat(res).Contains("Sub.demo2.txt");
        }

        /// <summary>
        /// Checks if the paths are correctly trimmed.
        /// </summary>
        [Fact]
        public static void TrimTest()
        {
            AssertThat(Resource.GetNames(".Sub.")).HasSize(2);
        }

        /// <summary>
        /// Checks if the paths with forward slashes are correctly found.
        /// </summary>
        [Fact]
        public static void ForwardSlashTest()
        {
            AssertThat(Resource.GetNames("/Sub")).HasSize(2);
        }

        /// <summary>
        /// Checks if the paths with backward slashes are correctly found.
        /// </summary>
        [Fact]
        public static void BackwardSlashTest()
        {
            AssertThat(Resource.GetNames("\\Sub")).HasSize(2);
        }
    }
}
