using Solar.Infrastructure.Config.GlobalStateObject;

namespace Solar.Infrastructure.Logging.GlobalStateObject.ConfigSections
{
    internal interface ILoggingConfig : IConfigSection
    {
        string LogFilePath { get; }
    }
}