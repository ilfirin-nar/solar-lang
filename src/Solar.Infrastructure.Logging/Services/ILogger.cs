using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.Logging.Services
{
    public interface ILogger : IInfrastructureService
    {
        void Fatal([NotNull] string message);

        void Error([NotNull] string message);

        void Warn([NotNull] string message);

        void Info([NotNull] string message);

        void Debug([NotNull] string message);

        void Trace([NotNull] string message);
    }
}