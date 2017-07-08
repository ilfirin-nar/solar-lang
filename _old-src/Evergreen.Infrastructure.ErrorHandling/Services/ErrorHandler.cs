using System;
using Evergreen.Infrastructure.Common.Exceptions;
using Evergreen.Infrastructure.ErrorHandling.Exceptions;
using Evergreen.Infrastructure.Logging.Services;

namespace Evergreen.Infrastructure.ErrorHandling.Services
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
            if (exception is EvergreenException)
            {
                return;
            }
            throw new FatalException(exception);
        }
    }
}