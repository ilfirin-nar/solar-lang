using System;
using LightInject;
using LightInject.xUnit2;
using Solar.Infrastructure.Config.Services;
using Solar.Infrastructure.Logging.Services;
using Xunit;

namespace Solar.Infrastructure.Logging.Tests.Services
{
    public class ExceptionsLoggerTests : LoggingTestsBase
    {
        private static IServiceContainer _container;

        public static void Configure(IServiceContainer container)
        {
            _container = container;
        }

        public ExceptionsLoggerTests()
        {
            var configurator = _container.GetInstance<IConfigurator>();
            Configure(configurator);
        }

        [Theory, InjectData]
        internal void Log_ValidException_ValidLevel(IExceptionsLogger logger)
        {
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

        [Theory, InjectData]
        internal void Log_ValidException_ValidStackTrace(IExceptionsLogger logger)
        {
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

        [Theory, InjectData]
        internal void Log_ValidException_ValidMessage(IExceptionsLogger logger)
        {
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

        [Theory, InjectData]
        internal void Log_ValidException_NullInnerException(IExceptionsLogger logger)
        {
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

        [Theory, InjectData]
        internal void Log_ValidExceptionWithInnerException_ValidInnerException(IExceptionsLogger logger)
        {
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