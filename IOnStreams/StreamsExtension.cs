// <copyright file="StreamsExtensions.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace IOnStreams
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>Class that works with the files</summary>
    public static class StreamsExtension
    {
        /// <summary>
        /// By byte copies file using FileStream as a backing store stream.
        /// </summary>
        /// <param name="sourcePath">Source file path</param>
        /// <param name="destinationPath">Destination file path</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <returns>Number of bytes that were copied</returns>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using var fileStream = new FileStream(destinationPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using var fs = new FileStream(sourcePath, FileMode.Open, FileAccess.ReadWrite);
            fileStream.SetLength(fs.Length);

            int bufferSize = 1024 * 1024;
            var bytes = new byte[bufferSize];

            int bytesRead = -1;
            while((bytesRead = fs.Read(bytes, 0, bufferSize)) > 0)
            {
                fileStream.Write(bytes, 0, bytesRead);
            }

            return (int)fileStream.Length;
        }

        /// <summary> By byte copies a file using the <see cref="MemoryStream"/> class</summary>
        /// <param name="sourcePath">Source file's path</param>
        /// <param name="destinationPath">New file's path</param>
        /// <returns>A count of written bytes</returns>
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            var encoding = Encoding.Default;
            byte[] bytes;

            using (StreamReader reader = new StreamReader(sourcePath))
            {
                bytes = encoding.GetBytes(reader.ReadToEnd());
            }

            using var memeStream = new MemoryStream(bytes.Length);

            var count = 0;
            while (count < bytes.Length) 
            {
                memeStream.WriteByte(bytes[count++]);
            }

            memeStream.Seek(0, SeekOrigin.Begin);

            bytes = new byte[memeStream.Length];
            count = memeStream.Read(bytes, 0, bytes.Length);

            var charArray = new char[encoding.GetCharCount(bytes, 0, count)];
            encoding.GetDecoder().GetChars(bytes, 0, count, charArray, 0);

            using var sw = new StreamWriter(destinationPath);
            
            sw.Write(charArray);

            return count;
        }

        /// <summary>
        /// By block copies a file using the <see cref="FileStream"/> instances
        /// </summary>
        /// <param name="sourcePath">Source file's path</param>
        /// <param name="destinationPath">New file's path</param>
        /// <returns>A count of written bytes</returns>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using var fs1 = new FileStream(sourcePath, FileMode.Open);
            using var fs2 = new FileStream(destinationPath, FileMode.OpenOrCreate);

            byte[] bytes = new byte[fs1.Length];
            fs1.Read(bytes, 0, bytes.Length);
            fs2.Write(bytes);

            return bytes.Length;
        }

        /// <summary> By block copies a file using the <see cref="MemoryStream"/> class</summary>
        /// <param name="sourcePath">Source file's path</param>
        /// <param name="destinationPath">New file's path</param>
        /// <returns>A count of written bytes</returns>
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            var encoding = Encoding.Default;
            byte[] bytes;

            using (StreamReader reader = new StreamReader(sourcePath))
            {
                bytes = encoding.GetBytes(reader.ReadToEnd());
            }

            using var memeStream = new MemoryStream();

            memeStream.Write(bytes, 0, bytes.Length);

            memeStream.Seek(0, SeekOrigin.Begin);

            bytes = new byte[memeStream.Length];
            var count = memeStream.Read(bytes, 0, bytes.Length);

            var charArray = new char[encoding.GetCharCount(bytes, 0, count)];
            encoding.GetDecoder().GetChars(bytes, 0, count, charArray, 0);

            using var sw = new StreamWriter(destinationPath);
            sw.Write(charArray);

            return count;
        }

        /// <summary>
        /// Copies the file by using the <see cref="BufferedStream"/> class
        /// </summary>
        /// <param name="sourcePath">Source file path</param>
        /// <param name="destinationPath">New file's path</param>
        /// <returns>A count of written bytes</returns>
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using var readStream = new FileStream(sourcePath, FileMode.Open);
            using var writeStream = new FileStream(destinationPath, FileMode.OpenOrCreate);
            using var bufReadStream = new BufferedStream(readStream);
            using var bufWriteStream = new BufferedStream(writeStream);

            var bytes = new byte[bufReadStream.Length];
            bufReadStream.Read(bytes, 0, bytes.Length);
            bufWriteStream.Write(bytes);

            return bytes.Length;
        }

        /// <summary>Line by line copies a source file to the new path</summary>
        /// <param name="sourcePath">Source Path</param>
        /// <param name="destinationPath">Path to writing data into</param>
        /// <returns>A count of written lines</returns>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using var fs1 = new FileStream(sourcePath, FileMode.Open);
            using var fs2 = new FileStream(destinationPath, FileMode.OpenOrCreate);

            using var reader = new StreamReader(fs1);
            using var writer = new StreamWriter(fs2);

            int count = 0;
            while (!reader.EndOfStream)
            {
                count++;
                writer.WriteLine(reader.ReadLine());
            }

            return count;
        }

        /// <summary>
        /// Compares two given files. Returns false if files don't exist
        /// </summary>
        /// <param name="sourcePath">First file</param>
        /// <param name="destinationPath">Second file</param>
        /// <returns>True if equal.</returns>
        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            if(!File.Exists(sourcePath) || !File.Exists(destinationPath))
            {
                return false;
            }

            if (sourcePath == destinationPath)
            {
                return true;
            }

            using var fs1 = new FileStream(sourcePath, FileMode.Open);
            using var fs2 = new FileStream(destinationPath, FileMode.Open);
            if (fs1.Length != fs2.Length)
            {
                return false;
            }

            int fs1bytes;
            int fs2bytes;
            do
            {
                fs1bytes = fs1.ReadByte();
                fs2bytes = fs2.ReadByte();
            }
            while ((fs1bytes == fs2bytes) && (fs1bytes != -1));

            return fs1bytes == fs2bytes;
        }

        /// <summary>Validates if given inputs are fine. Throws an exception if they are not</summary>
        /// <param name="sourcePath">Source file</param>
        /// <param name="destinationPath">New file's path</param>
        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException();
            }

            if (!Directory.Exists(Path.GetDirectoryName(destinationPath)) 
                || string.IsNullOrEmpty(Path.GetFileName(destinationPath)))
            {

                throw new DirectoryNotFoundException();
            }
        }
    }
}