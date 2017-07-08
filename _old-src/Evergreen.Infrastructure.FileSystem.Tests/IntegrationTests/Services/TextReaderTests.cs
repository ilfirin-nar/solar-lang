using Evergreen.Infrastructure.FileSystem.Services;
using Photosphere.DependencyInjection.xUnit;
using Xunit;

namespace Evergreen.Infrastructure.FileSystem.Tests.IntegrationTests.Services
{
    public class TextReaderTests : TextReadersTestsBase
    {
        [Theory, InjectDependency]
        internal void Read_ValidFilePath_Success(ITextFileReader fileReader)
        {
            var result = fileReader.Read(TestFilePath);
            Assert.Equal(FileContent, result);
        }
    }
}