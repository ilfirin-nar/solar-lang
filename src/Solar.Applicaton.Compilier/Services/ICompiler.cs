using Solar.Application.Compiler.DataTransferObjects;
using Solar.Infrastructure.Common.Interfaces.ApplicationLayer;

namespace Solar.Application.Compiler.Services
{
    public interface ICompiler : IApplicationService
    {
        void Compile(ModulesPathes modulesPathes);
    }
}