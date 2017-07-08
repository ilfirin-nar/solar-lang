using Evergreen.Application.Compiler.DataTransferObjects;
using Evergreen.Application.Compiler.Services;
using Evergreen.Frontend.Compiler.DataTransferObjects;
using Photosphere.Console.Actions;
using Photosphere.Mapping.Extensions;

namespace Evergreen.Frontend.Compiler.Services.Actions
{
    internal class CompileAction : ICommandLineAction<ICompilerArguments>
    {
        private readonly ICompiler _compiler;

        public CompileAction(ICompiler compiler)
        {
            _compiler = compiler;
        }

        public void Action(ICompilerArguments arguments)
        {
            var modulesPathes = arguments.Map<ICompilerArguments, ModulesPathes>();
            _compiler.Compile(modulesPathes);
        }
    }
}