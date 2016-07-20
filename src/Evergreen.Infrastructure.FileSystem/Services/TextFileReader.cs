using System.IO;

namespace Evergreen.Infrastructure.FileSystem.Services
{
    internal class TextFileReader : ITextFileReader
    {
        public string Read(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}