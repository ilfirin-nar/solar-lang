using Evergreen.Infrastructure.Configuration.GlobalStateObject;

namespace Evergreen.Infrastructure.Logging.GlobalStateObject.ConfigSections
{
    public interface ILoggingConfig : IConfigSection
    {
        string LogFilePath { get; }
    }
}