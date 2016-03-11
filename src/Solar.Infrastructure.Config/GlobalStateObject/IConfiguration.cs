using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.Config.DataTransferObjects;

namespace Solar.Infrastructure.Config.GlobalStateObject
{
    public interface IConfiguration : IGlobalStateObject
    {
        [NotNull]
        TConfigOption Get<TConfigOption>() where TConfigOption : IConfigSection;
    }
}