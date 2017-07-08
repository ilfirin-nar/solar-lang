using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using JetBrains.Annotations;

namespace Evergreen.Infrastructure.FileSystem.Services
{
    public interface ITextFileWriter : IInfrastructureService
    {
        void Write([NotNull] string filePath, [NotNull] string text);
    }
}