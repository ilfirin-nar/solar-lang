using System;
using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.Logging.Services
{
    public interface IExceptionsLogger : IInfrastructureService
    {
        void Log([NotNull] Exception exception);
    }
}