using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.Logging.Services
{
    public interface ILogger : IInfrastructureService
    {
        void Fatal([NotNull] object message);

        void Error([NotNull] object message);

        void Warn([NotNull] object message);

        void Info([NotNull] object message);

        void Debug([NotNull] object message);

        void Trace([NotNull] object message);
    }
}