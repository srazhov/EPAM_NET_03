// <copyright file="StreamsExtensionTest.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace IOnStreams.Tests
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using static IOnStreams.StreamsExtension;

    /// <summary>
    /// Test of the <see cref="StreamsExtension"/> static class
    /// </summary>
    public class StreamsExtensionTest
    {
        /// <summary> Source File's path </summary>
        private string sourceFile;

        /// <summary> Destination Folder's path </summary>
        private string destinationFolder;

        private const int expectedBytes = 9482;

        /// <summary>Set up</summary>
        [SetUp]
        public void SetUp()
        {
            var path = Environment.CurrentDirectory;
            path = path.Replace("\\bin\\Debug\\netcoreapp3.1", string.Empty);

            sourceFile = Path.Combine(path, @"SourceText.txt");
            destinationFolder = Path.Combine(path, "Results\\");
        }

        /// <summary>Test of the <see cref="ByByteCopy(string, string)"/> method</summary>
        [Test]
        public void ByByteCopyTest()
        {
            var dest = destinationFolder + "ByByteCopiedText.txt";
            var actual = ByByteCopy(sourceFile, dest);

            Assert.AreEqual(expectedBytes, actual);
            Assert.That(IsContentEquals(sourceFile, dest));
        }

        /// <summary>Test of the <see cref="InMemoryByByteCopy(string, string)"/> method</summary>
        [Test]
        public void InMemoryByByteCopyTest()
        {
            var dest = destinationFolder + "InMemoryByByteText.txt";

            var actual = InMemoryByByteCopy(sourceFile, dest);

            Assert.AreEqual(9479, actual);
        }

        /// <summary>Test of the <see cref="ByBlockCopy(string, string)"/> method</summary>
        [Test]
        public void ByBlockCopyTest()
        {
            var dest = destinationFolder + "ByBlockCopiedText.txt";
            var actual = ByByteCopy(sourceFile, dest);

            Assert.AreEqual(expectedBytes, actual);
            Assert.That(IsContentEquals(sourceFile, dest));
        }

        /// <summary>Test of the <see cref="InMemoryByBlockCopy(string, string)"/> method</summary>
        [Test]
        public void InMemoryByBlockCopyTest()
        {
            var dest = destinationFolder + "InMemoryByBlockText.txt";

            var actual = InMemoryByBlockCopy(sourceFile, dest);

            Assert.AreEqual(9479, actual);
        }

        /// <summary>Test of the <see cref="BufferedCopy(string, string)"/> method</summary>
        [Test]
        public void BufferedCopyTest()
        {
            var destination = destinationFolder + "BufferedCopiedText.txt";

            var actual = BufferedCopy(sourceFile, destination);

            Assert.AreEqual(expectedBytes, actual);
            Assert.That(IsContentEquals(sourceFile, destination));
        }

        /// <summary>Test of the <see cref="ByLineCopy(string, string)"/> method</summary>
        [Test]
        public void ByLineCopyTest()
        {
            var expected = 79;
            var actual = ByLineCopy(sourceFile, destinationFolder + "ByLineCopiedText.txt");

            Assert.AreEqual(expected, actual);
        }

        /// <summary>Test of the <see cref="IsContentEquals(string, string)"/> method</summary>
        [Test]
        public void IsContentEqualTest()
        {
            var exp = true;

            var actual = IsContentEquals(sourceFile, destinationFolder + "ByByteCopiedText.txt");

            Assert.AreEqual(exp, actual);
        }
    }
}