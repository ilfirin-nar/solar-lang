using System;
using Solar.Infrastructure.Logging.DataTransferObjects;

namespace Solar.Infrastructure.Logging.Services.Mappers
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