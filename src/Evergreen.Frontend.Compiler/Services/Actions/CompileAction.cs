using Evergreen.Application.Compiler.DataTransferObjects;
using Evergreen.Application.Compiler.Services;
using Evergreen.Frontend.Compiler.DataTransferObjects;
using Evergreen.Infrastructure.Common.Services;
using Evergreen.Infrastructure.Console.Actions;

namespace Evergreen.Frontend.Compiler.Services.Actions
{
    internal class CompileAction : ICommandLineAction<ICompilerArguments>
    {
        private readonly IMapper<ICompilerArguments, ModulesPathes> _mapper;
        private readonly ICompiler _compiler;

        public CompileAction(
            IMapper<ICompilerArguments, ModulesPathes> mapper,
            ICompiler compiler)
        {
            _mapper = mapper;
            _compiler = compiler;
        }

        public void Action(ICompilerArguments arguments)
        {
            var modulesPathes = _mapper.Map(arguments);
            _compiler.Compile(modulesPathes);
        }
    }
}