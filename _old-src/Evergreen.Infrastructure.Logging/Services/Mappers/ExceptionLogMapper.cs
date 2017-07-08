using System;
using Evergreen.Infrastructure.Logging.DataTransferObjects;

namespace Evergreen.Infrastructure.Logging.Services.Mappers
{
    internal class ExceptionLogMapper : IExceptionLogMapper
    {
        public ExceptionLogMessage Map(Exception exception)
        {
            return new ExceptionLogMessage
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                InnerException = exception.InnerException == null ? null : Map(exception.InnerException)
            };
        }
    }
}