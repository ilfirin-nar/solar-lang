using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Evergreen.Infrastructure.FileSystem.Services
{
    public interface ITextFileReader : IInfrastructureService
    {
        string Read(string path);
    }
}