using System;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.Logging.Services
{
    public interface IExceptionsLogger : IInfrastructureService
    {
        void Log(Exception exception);
    }
}