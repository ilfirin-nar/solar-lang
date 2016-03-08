using System;
using Solar.Application.Compiler.Services;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Frontend.Compiler.Services.Mapper;
using Solar.Infrastructure.Console.Arguments.Services;
using Solar.Infrastructure.ErrorHandling.Services;
using Solar.Infrastructure.Logging.Services;

namespace Solar.Frontend.Compiler.Services
{
    internal class CompilerProgram : ICompilerProgram
    {
        private readonly ICommandLineArgumentsParser<CompilerArguments> _commandLineArgumentsParser;
        private readonly ICompilerArgumentsMapper _mapper;
        private readonly ICompiler _compiler;

        public CompilerProgram(
            ICommandLineArgumentsParser<CompilerArguments> commandLineArgumentsParser,
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