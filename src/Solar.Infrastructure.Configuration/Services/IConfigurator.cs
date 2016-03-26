using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.Configuration.Services
{
    public interface IConfigurator : IInfrastructureService
    {
        void Configure();

        void Configure([NotNull] string configString);
    }
}