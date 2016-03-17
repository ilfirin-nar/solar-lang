using Solar.Application.Compiler.DataTransferObjects;
using Solar.Application.Compiler.Services;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Infrastructure.Common.Services;

namespace Solar.Frontend.Compiler.Services.Actions
{
    internal class CompileAction : ICommandLineAction
    {
        private readonly IDataMapper<ICompilerArguments, ModulesPathes> _mapper;
        private readonly ICompiler _compiler;

        public CompileAction(
            IDataMapper<ICompilerArguments, ModulesPathes> mapper,
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