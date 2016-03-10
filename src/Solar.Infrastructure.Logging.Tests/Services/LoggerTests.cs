using LightInject.xUnit2;
using Solar.Infrastructure.Common.Extensions;
using Solar.Infrastructure.Logging.Services;
using Xunit;

namespace Solar.Infrastructure.Logging.Tests.Services
{
    public class LoggerTests : LoggingTestsBase
    {
        [Theory]
        [InjectData("Fatal", "FATAL", "fatal test log")]
        [InjectData("Error", "ERROR", "error test log")]
        [InjectData("Warn", "WARN", "warn test log")]
        [InjectData("Info", "INFO", "info test log")]
        [InjectData("Debug", "DEBUG", "debug test log")]
        [InjectData("Trace", "TRACE", "trace test log")]
        internal void LogMethod_ValidMessage_ValidLog(ILogger logger, string logMethodName, string level, string message)
        {
            logger.InvokeMethod(logMethodName, message);
            var result = GetLogText();
            Assert.True(result.Contains(level));
            Assert.True(result.Contains(message));
        }
    }
}