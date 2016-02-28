using System;
using System.IO;
using LightInject.xUnit2;
using Solar.Infrastructure.FileSystem.Services;
using Xunit;

namespace Solar.Infrastructure.FileSystem.Tests.Services
{
    public class TextReaderTests : IDisposable
    {
        private readonly string _testFilePath = $"{Directory.GetCurrentDirectory()}\\file-for-tests-{Guid.NewGuid()}.txt";

        private const string FileContent = "It is content in file for tests.";

        public TextReaderTests()
        {
            if (File.Exists(_testFilePath))
            {
                return;
            }
            using (var sw = File.CreateText(_testFilePath))
            {
                sw.Write(FileContent);
            }
        }

        public void Dispose()
        {
            File.Delete(_testFilePath);
        }

        [Theory, InjectData]
        internal void Read_ValidFilePath_Success(ITextFileReader fileReader)
        {
            var result = fileReader.Read(_testFilePath);
            Assert.Equal(FileContent, result);
        }
    }
}