using LightInject.xUnit2;
using Solar.Infrastructure.FileSystem.Services;
using Xunit;

namespace Solar.Infrastructure.FileSystem.Tests.Services
{
    public class TextReaderTests : TextReadersTestsBase
    {
        [Theory, InjectData]
        internal void Read_ValidFilePath_Success(ITextFileReader fileReader)
        {
            var result = fileReader.Read(TestFilePath);
            Assert.Equal(FileContent, result);
        }
    }
}