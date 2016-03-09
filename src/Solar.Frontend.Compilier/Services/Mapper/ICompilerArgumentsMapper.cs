using Solar.Application.Compiler.DataTransferObjects;
using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;
using Solar.Infrastructure.Common.Services;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Solar.Frontend.Compiler.Services.Mapper
{
    public interface ICompilerArgumentsMapper : IDataMapper<ICommandLineArguments, IModulesPathes>  {}
}