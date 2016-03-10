using System;
using System.IO;

namespace Solar.Infrastructure.Logging.Tests.Services
{
    public abstract class LoggingTestsBase : IDisposable
    {
        protected readonly string LogFilePath = Directory.GetCurrentDirectory() + "\\log.log";

        public void Dispose()
        {
            File.Delete(LogFilePath);
        }

        protected string GetLogText()
        {
            return File.ReadAllText(LogFilePath);
        }
    }
}