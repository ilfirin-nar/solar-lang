using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Infrastructure.FileSystem.Services
{
    public interface IJsonFileParser : IInfrastructureService
    {
        [NotNull]
        IList<object> ParseNestedObject([NotNull] string jsonFilePath, [NotNull] IEnumerable<Type> types);
    }
}