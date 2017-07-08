using Evergreen.Application.Compiler.DataTransferObjects;
using Evergreen.Infrastructure.Common.Interfaces.ApplicationLayer;

namespace Evergreen.Application.Compiler.Services
{
    public interface ICompiler : IApplicationService
    {
        void Compile(ModulesPathes modulesPathes);
    }
}