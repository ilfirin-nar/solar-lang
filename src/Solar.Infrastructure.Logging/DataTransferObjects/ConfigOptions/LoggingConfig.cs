using Solar.Infrastructure.Config.DataTransferObjects;

namespace Solar.Infrastructure.Logging.DataTransferObjects.ConfigOptions
{
    public struct LoggingConfig : IConfigSection
    {
         public string LogFilePath { get; set; }
    }
}