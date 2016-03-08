using System.Collections.Generic;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Application.Compiler.DataTransferObjects
{
    public interface IModulesPathes : IDataTransferObject
    {
         IReadOnlyList<string> Pathes { get; }
    }
}