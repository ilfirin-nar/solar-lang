using System;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Evergreen.Infrastructure.Logging.DataTransferObjects;

namespace Evergreen.Infrastructure.Logging.Services.Mappers
{
    internal interface IExceptionLogMapper : IMapper
    {
        ExceptionLogMessage Map(Exception exception);
    }
}