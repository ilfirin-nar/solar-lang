using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.FileSystem.Services
{
    public interface ITextFileReader : IInfrastructureService
    {
        string Read(string path);
    }
}