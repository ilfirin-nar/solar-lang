using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Evergreen.Infrastructure.Logging.Constants;
using Evergreen.Infrastructure.Logging.DataTransferObjects;
using JetBrains.Annotations;

namespace Evergreen.Infrastructure.Logging.Services.Mappers
{
    internal interface ILogMapper : IMapper
    {
        Log Map([NotNull] object message, LoggingLevel level);
    }
}