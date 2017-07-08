using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using JetBrains.Annotations;

namespace Evergreen.Infrastructure.Configuration.Services
{
    public interface IConfigurator : IInfrastructureService
    {
        void Configure();

        void Configure([NotNull] string configString);
    }
}