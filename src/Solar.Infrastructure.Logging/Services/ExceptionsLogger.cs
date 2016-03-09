using System;
using Solar.Infrastructure.Common.Exceptions;

namespace Solar.Infrastructure.Logging.Services
{
    internal class ExceptionsLogger : IExceptionsLogger
    {
        private readonly ILogger _logger;

        public ExceptionsLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(Exception exception)
        {
            if (exception is SolarException)
            {
                _logger.Error(exception.Message);
                return;
            }
            _logger.Fatal(exception.Message);
        }
    }
}