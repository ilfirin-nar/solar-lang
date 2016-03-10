using System;
using Solar.Infrastructure.Common.Exceptions;
using Solar.Infrastructure.Logging.Services.Mappers;

namespace Solar.Infrastructure.Logging.Services
{
    internal class ExceptionsLogger : IExceptionsLogger
    {
        private readonly IExceptionLogMapper _mapper;
        private readonly ILogger _logger;

        public ExceptionsLogger(
            IExceptionLogMapper mapper,
            ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public void Log(Exception exception)
        {
            var exceptionMessage = _mapper.Map(exception);
            if (exception is SolarException)
            {
                _logger.Error(exceptionMessage);
                return;
            }
            _logger.Fatal(exceptionMessage);
        }
    }
}