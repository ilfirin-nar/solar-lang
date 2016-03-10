using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.FileSystem.Services
{
    public interface ITextFileWriter : IInfrastructureService
    {
        void Write([NotNull] string filePath, [NotNull] string text);
    }
}