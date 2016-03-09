using System;
using Solar.Infrastructure.Common.Exceptions;
using Solar.Infrastructure.Logging.Services;

namespace Solar.Infrastructure.ErrorHandling.Services
{
    internal class ErrorHandler : IErrorHandler
    {
        private readonly ILogger _logger;

        public ErrorHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void Handle(Exception exception)
        {
            if (exception is CompilerException)
            {
                _logger.Error(exception.Message);
            }
            _logger.Fatal(exception.Message);
            throw new FatalException(exception);
        }
    }
}