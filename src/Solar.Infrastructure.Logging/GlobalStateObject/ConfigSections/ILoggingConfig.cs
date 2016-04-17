using Solar.Infrastructure.Configuration.GlobalStateObject;

namespace Solar.Infrastructure.Logging.GlobalStateObject.ConfigSections
{
    public interface ILoggingConfig : IConfigSection
    {
        string LogFilePath { get; }
    }
}