using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.FileSystem.Services
{
    public interface IJsonFileParser : IInfrastructureService
    {
        [NotNull]
        IList<object> ParseNestedObjectFromFile([NotNull] string jsonFilePath, [NotNull] IEnumerable<Type> types);

        [NotNull]
        IList<object> ParseNestedObjectFromString([NotNull] string jsonString, [NotNull] IEnumerable<Type> types);
    }
}