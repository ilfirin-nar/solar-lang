using Solar.Infrastructure.Config.GlobalStateObject;

namespace Solar.Infrastructure.Logging.GlobalStateObject.ConfigSections
{
    public class LoggingConfig : IConfigSection
    {
         public string LogFilePath { get; set; }
    }
}