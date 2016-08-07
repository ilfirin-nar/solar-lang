using System;
using Evergreen.Infrastructure.Configuration.Services;
using Evergreen.Infrastructure.Logging.Services;
using Photosphere.DependencyInjection.xUnit;
using Xunit;

namespace Evergreen.Infrastructure.Logging.Tests.IntegrationTests.Services
{
    public class ExceptionsLoggerTests : LoggingTestsBase
    {
        //private static IServiceContainer _container;

        //public static void Configure(IServiceContainer container)
        //{
        //    _container = container;
        //}

        //public ExceptionsLoggerTests()
        //{
        //    var configurator = _container.GetInstance<IConfigurator>();
        //    Configure(configurator);
        //}

        [Theory, InjectDependency]
        internal void Log_ValidException_ValidLevel(IExceptionsLogger logger, IConfigurator configurator)
        {
            Configure(configurator);
            try
            {
                throw new TestException();
            }
            catch (TestException exception)
            {
                logger.Log(exception);
                var result = GetLogText();
                Assert.True(result.Contains("FATAL"));
            }
        }

        [Theory, InjectDependency]
        internal void Log_ValidException_ValidStackTrace(IExceptionsLogger logger, IConfigurator configurator)
        {
            Configure(configurator);
            try
            {
                throw new TestException();
            }
            catch (TestException exception)
            {
                logger.Log(exception);
                var result = GetLogText();
                Assert.False(result.Contains("\"StackTrace\":null"));
            }
        }

        [Theory, InjectDependency]
        internal void Log_ValidException_ValidMessage(IExceptionsLogger logger, IConfigurator configurator)
        {
            Configure(configurator);
            try
            {
                throw new TestException();
            }
            catch (TestException exception)
            {
                logger.Log(exception);
                var result = GetLogText();
                Assert.True(result.Contains(exception.Message));
            }
        }

        [Theory, InjectDependency]
        internal void Log_ValidException_NullInnerException(IExceptionsLogger logger, IConfigurator configurator)
        {
            Configure(configurator);
            try
            {
                throw new TestException();
            }
            catch (TestException exception)
            {
                logger.Log(exception);
                var result = GetLogText();
                Assert.True(result.Contains("\"InnerException\":null"));
            }
        }

        [Theory, InjectDependency]
        internal void Log_ValidExceptionWithInnerException_ValidInnerException(IExceptionsLogger logger, IConfigurator configurator)
        {
            Configure(configurator);
            try
            {
                try
                {
                    throw new TestInnerException();
                }
                catch (TestInnerException exception)
                {
                    throw new TestException(exception);
                }
            }
            catch (TestException exception)
            {
                logger.Log(exception);
                var result = GetLogText();
                Assert.False(result.Contains("\"InnerException\":\"null\""));
                Assert.True(result.Contains(exception.InnerException.Message));
            }
        }

        private class TestException : Exception
        {
            private const string MessageString = "Test exception message";

            public TestException() {}

            public TestException(Exception innerException) : base(MessageString, innerException) {}

            public override string Message => MessageString;
        }

        private class TestInnerException : Exception
        {
            public override string Message => "Test inner exception message";
        }
    }
}