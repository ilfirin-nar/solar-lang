using System;
using Solar.Infrastructure.Logging.Constants;
using Solar.Infrastructure.Logging.DataTransferObjects;

namespace Solar.Infrastructure.Logging.Services.Mappers
{
    internal class LogMapper : ILogMapper
    {
        public Log Map(object message, LoggingLevel level)
        {
            return new Log
            {
                DateTime = DateTime.Now,
                Level = level.ToString("F").ToUpper(),
                Message = message
            };
        }
    }
}