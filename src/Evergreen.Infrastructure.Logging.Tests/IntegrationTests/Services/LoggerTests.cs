using Evergreen.Infrastructure.Common.Extensions.ObjectExtensions;
using Evergreen.Infrastructure.Configuration.Services;
using Evergreen.Infrastructure.Logging.Services;
using LightInject;
using LightInject.xUnit2;
using Xunit;

namespace Evergreen.Infrastructure.Logging.Tests.IntegrationTests.Services
{
    public class LoggerTests : LoggingTestsBase
    {
        private static IServiceContainer _container;

        public static void Configure(IServiceContainer container)
        {
            _container = container;
        }

        public LoggerTests()
        {
            var configurator = _container.GetInstance<IConfigurator>();
            Configure(configurator);
        }

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

        [Theory, InjectData]
        internal void LogMethod_TwoValidMessage_ValidLog(ILogger logger, IConfigurator configurator)
        {
            Configure(configurator);
            const string foo = "foo";
            const string bar = "bar";
            logger.Info(foo);
            logger.Info(bar);
            var result = GetLogText();
            Assert.True(result.Contains(foo));
            Assert.True(result.Contains(bar));
        }
    }
}