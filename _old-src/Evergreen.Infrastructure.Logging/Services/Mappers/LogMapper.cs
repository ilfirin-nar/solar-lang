using System;
using Evergreen.Infrastructure.Logging.Constants;
using Evergreen.Infrastructure.Logging.DataTransferObjects;

namespace Evergreen.Infrastructure.Logging.Services.Mappers
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