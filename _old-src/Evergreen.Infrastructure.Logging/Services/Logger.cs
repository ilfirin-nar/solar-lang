using Evergreen.Infrastructure.FileSystem.Services;
using Evergreen.Infrastructure.Logging.Constants;
using Evergreen.Infrastructure.Logging.GlobalStateObject.ConfigSections;
using Evergreen.Infrastructure.Logging.Services.Mappers;
using Newtonsoft.Json;

namespace Evergreen.Infrastructure.Logging.Services
{
    internal class Logger : ILogger
    {
        private readonly ITextFileWriter _fileWriter;
        private readonly ILogMapper _mapper;
        private readonly ILoggingConfig _config;

        public Logger(
            ITextFileWriter fileWriter,
            ILogMapper mapper,
            ILoggingConfig config)
        {
            _fileWriter = fileWriter;
            _mapper = mapper;
            _config = config;
        }

        public void Fatal(object message)
        {
            Log(message, LoggingLevel.Fatal);
        }

        public void Error(object message)
        {
            Log(message, LoggingLevel.Error);
        }

        public void Warn(object message)
        {
            Log(message, LoggingLevel.Warn);
        }

        public void Info(object message)
        {
            Log(message, LoggingLevel.Info);
        }

        public void Debug(object message)
        {
            Log(message, LoggingLevel.Debug);
        }

        public void Trace(object message)
        {
            Log(message, LoggingLevel.Trace);
        }

        private void Log(object message, LoggingLevel level)
        {
            var log = _mapper.Map(message, level);
            var logJson = JsonConvert.SerializeObject(log);
            _fileWriter.Write(_config.LogFilePath, logJson);
        }
    }
}