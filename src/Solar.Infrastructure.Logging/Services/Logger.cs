using JetBrains.Annotations;

namespace Solar.Infrastructure.Logging.Services
{
    internal class Logger : ILogger
    {
        public void Fatal([NotNull] string message)
        {
            throw new System.NotImplementedException();
        }

        public void Error([NotNull] string message)
        {
            throw new System.NotImplementedException();
        }

        public void Warn([NotNull] string message)
        {
            throw new System.NotImplementedException();
        }

        public void Info([NotNull] string message)
        {
            throw new System.NotImplementedException();
        }

        public void Debug([NotNull] string message)
        {
            throw new System.NotImplementedException();
        }

        public void Trace([NotNull] string message)
        {
            throw new System.NotImplementedException();
        }
    }
}