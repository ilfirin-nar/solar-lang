using System.IO;

namespace Solar.Infrastructure.FileSystem.Services
{
    internal class TextFileWriter : ITextFileWriter
    {
        public void Write(string filePath, string text)
        {
            if (!File.Exists(filePath))
            {
                using (var writer = File.CreateText(filePath))
                {
                    writer.WriteLineAsync(text);
                    return;
                }
            }
            using (var writer = File.AppendText(filePath))
            {
                writer.WriteLineAsync(text);
            }
        }
    }
}