using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.Logging.Constants;
using Solar.Infrastructure.Logging.DataTransferObjects;

namespace Solar.Infrastructure.Logging.Services.Mappers
{
    internal interface ILogMapper : IMapper
    {
        Log Map([NotNull] object message, LoggingLevel level);
    }
}