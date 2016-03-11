using System;
using System.IO;

namespace Solar.Infrastructure.FileSystem.Tests.Services
{
    public class TextReadersTestsBase : IDisposable
    {
        protected readonly string TestFilePath = $"{Directory.GetCurrentDirectory()}\\file-for-tests-{Guid.NewGuid()}.txt";

        protected virtual string FileContent => "It is content in file for tests.";

        protected TextReadersTestsBase()
        {
            if (File.Exists(TestFilePath))
            {
                return;
            }
            using (var sw = File.CreateText(TestFilePath))
            {
                sw.Write(FileContent);
            }
        }

        public void Dispose()
        {
            File.Delete(TestFilePath);
        }
    }
}