using LightInject.xUnit2;
using Solar.Infrastructure.Console.Services;
using Solar.Infrastructure.Console.Tests.Services.TestDataTransferObjects;
using Xunit;

namespace Solar.Infrastructure.Console.Tests.Services
{
    public class CommandLineArgumentsParserTests
    {
        [Theory]
        [InjectData("-f fooValue -b 42 -r", "fooValue", 42, true)]
        public static void Parse_ValidStringWithoutArray_ValidDto(
            ICommandLineArgumentsParser<TestCommandLineArguments> parser,
            string args,
            string foo,
            int bar,
            bool isRock)
        {
            var result = parser.Parse(args.Split(' '));
            Assert.Equal(foo, result.Foo);
            Assert.Equal(bar, result.Bar);
            Assert.Equal(isRock, result.IsRock);
        }
    }
}