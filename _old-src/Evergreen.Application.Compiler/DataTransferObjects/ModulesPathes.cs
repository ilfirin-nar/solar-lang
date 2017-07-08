using System.Collections.Generic;
using Evergreen.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Evergreen.Application.Compiler.DataTransferObjects
{
    public class ModulesPathes : IDataTransferObject
    {
         IReadOnlyList<string> Pathes { get; }
    }
}