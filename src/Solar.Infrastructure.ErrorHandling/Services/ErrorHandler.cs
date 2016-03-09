using System;
using Solar.Infrastructure.Common.Exceptions;
using Solar.Infrastructure.ErrorHandling.Exceptions;
using Solar.Infrastructure.Logging.Services;

namespace Solar.Infrastructure.ErrorHandling.Services
{
    internal class ErrorHandler : IErrorHandler
    {
        private readonly IExceptionsLogger _logger;

        public ErrorHandler(IExceptionsLogger logger)
        {
            _logger = logger;
        }

        public void Handle(Exception exception)
        {
            _logger.Log(exception);
            if (exception is SolarException)
            {
                return;
            }
            throw new FatalException(exception);
        }
    }
}