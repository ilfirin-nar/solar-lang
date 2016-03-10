using System;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.Logging.DataTransferObjects;

namespace Solar.Infrastructure.Logging.Services.Mappers
{
    internal interface IExceptionLogMapper : IMapper
    {
        ExceptionLogMessage Map(Exception exception);
    }
}