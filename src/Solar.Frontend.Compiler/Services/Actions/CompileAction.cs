using Solar.Application.Compiler.DataTransferObjects;
using Solar.Application.Compiler.Services;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Infrastructure.Common.Services;

namespace Solar.Frontend.Compiler.Services.Actions
{
    internal class CompileAction : ICommandLineAction
    {
        private readonly IDataMapper<CompilerArguments, ModulesPathes> _mapper;
        private readonly ICompiler _compiler;

        public CompileAction(
            IDataMapper<CompilerArguments, ModulesPathes> mapper,
            ICompiler compiler)
        {
            _mapper = mapper;
            _compiler = compiler;
        }

        public void Action(CompilerArguments arguments)
        {
            var modulesPathes = _mapper.Map(arguments);
            _compiler.Compile(modulesPathes);
        }
    }
}