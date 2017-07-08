using System;
using System.Collections.Generic;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;
using JetBrains.Annotations;

namespace Evergreen.Infrastructure.FileSystem.Services
{
    public interface IJsonFileParser : IInfrastructureService
    {
        [NotNull]
        IList<object> ParseNestedObjectFromFile([NotNull] string jsonFilePath, [NotNull] IEnumerable<Type> types);

        [NotNull]
        IList<object> ParseNestedObjectFromString([NotNull] string jsonString, [NotNull] IEnumerable<Type> types);
    }
}