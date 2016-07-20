using System;
using System.IO;
using Evergreen.Infrastructure.Configuration.Services;
using Evergreen.Infrastructure.Logging.GlobalStateObject.ConfigSections;
using Newtonsoft.Json;

namespace Evergreen.Infrastructure.Logging.Tests.IntegrationTests.Services
{
    public abstract class LoggingTestsBase : IDisposable
    {
        private string _logFilePath;

        protected void Configure(IConfigurator configurator)
        {
            _logFilePath = $"log-{Guid.NewGuid()}.log";
            var configSectionJsonString = JsonConvert.SerializeObject(new LoggingConfig { LogFilePath = _logFilePath });
            var configJsonString =  $"{{ \"{typeof (LoggingConfig).Name}\": {configSectionJsonString} }}";
            configurator.Configure(configJsonString);
        }

        public void Dispose()
        {
            File.Delete(_logFilePath);
        }

        protected string GetLogText()
        {
            return File.ReadAllText(_logFilePath);
        }
    }
}