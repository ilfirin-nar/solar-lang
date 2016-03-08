using Solar.Application.Compiler.Services;
using Solar.Frontend.Compiler.Services.Mapper;
using Solar.Infrastructure.Console.Services;

namespace Solar.Frontend.Compiler.Services
{
    internal class CompilerProgram : ICompilerProgram
    {
        private readonly ICommandLineArgumentsParser _commandLineArgumentsParser;
        private readonly ICompilerArgumentsMapper _mapper;
        private readonly ICompiler _compiler;

        public CompilerProgram(
            ICommandLineArgumentsParser commandLineArgumentsParser,
            ICompilerArgumentsMapper mapper,
            ICompiler compiler)
        {
            _commandLineArgumentsParser = commandLineArgumentsParser;
            _mapper = mapper;
            _compiler = compiler;
        }

        public void Start(string[] args)
        {
            var arguments = _commandLineArgumentsParser.Parse(args);
            var result = _mapper.Map(arguments);
            _compiler.Compile(result);
        }
    }
}