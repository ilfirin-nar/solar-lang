using System.IO;
using Newtonsoft.Json;
using Solar.Infrastructure.FileSystem.Services;
using Solar.Infrastructure.Logging.Constants;
using Solar.Infrastructure.Logging.Services.Mappers;

namespace Solar.Infrastructure.Logging.Services
{
    internal class Logger : ILogger
    {
        private static readonly string StandartLogFilePath;
        private readonly ITextFileWriter _fileWriter;
        private readonly ILogMapper _mapper;

        static Logger()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            StandartLogFilePath = currentDirectory + "\\log.log";
        }

        public Logger(ITextFileWriter fileWriter, ILogMapper mapper)
        {
            _fileWriter = fileWriter;
            _mapper = mapper;
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
            _fileWriter.Write(StandartLogFilePath, logJson);
        }
    }
}