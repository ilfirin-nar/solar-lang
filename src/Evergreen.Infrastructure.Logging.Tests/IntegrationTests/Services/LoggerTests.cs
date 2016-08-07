using Evergreen.Infrastructure.Common.Extensions;
using Evergreen.Infrastructure.Configuration.Services;
using Evergreen.Infrastructure.Logging.Services;
using Photosphere.DependencyInjection.xUnit;
using Xunit;

namespace Evergreen.Infrastructure.Logging.Tests.IntegrationTests.Services
{
    public class LoggerTests : LoggingTestsBase
    {
        //private static IServiceContainer _container;

        //public static void Configure(IServiceContainer container)
        //{
        //    _container = container;
        //}

        //public LoggerTests()
        //{
        //    var configurator = _container.GetInstance<IConfigurator>();
        //    Configure(configurator);
        //}

        [Theory]
        [InjectDependency("Fatal", "FATAL", "fatal test log")]
        [InjectDependency("Error", "ERROR", "error test log")]
        [InjectDependency("Warn", "WARN", "warn test log")]
        [InjectDependency("Info", "INFO", "info test log")]
        [InjectDependency("Debug", "DEBUG", "debug test log")]
        [InjectDependency("Trace", "TRACE", "trace test log")]
        internal void LogMethod_ValidMessage_ValidLog(string logMethodName, string level, string message, ILogger logger, IConfigurator configurator)
        {
            Configure(configurator);
            logger.InvokeMethod(logMethodName, message);
            var result = GetLogText();
            Assert.True(result.Contains(level));
            Assert.True(result.Contains(message));
        }

        [Theory, InjectDependency]
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