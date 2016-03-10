using System.IO;

namespace Solar.Infrastructure.FileSystem.Services
{
    internal class TextFileWriter : ITextFileWriter
    {
        public void Write(string filePath, string text)
        {
            using (var outputFile = new StreamWriter(filePath))
            {
                outputFile.WriteLine(text);
            }
        }
    }
}