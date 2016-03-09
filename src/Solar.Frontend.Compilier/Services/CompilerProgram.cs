using System.Collections.Generic;
using Solar.Application.Compiler.DataTransferObjects;
using Solar.Application.Compiler.Services;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Infrastructure.Common.Services;
using Solar.Infrastructure.Console.Arguments.Services;

namespace Solar.Frontend.Compiler.Services
{
    internal class CompilerProgram : ICompilerProgram
    {
        private readonly ICommandLineArgumentsParser<CompilerArguments> _commandLineArgumentsParser;
        private readonly IDataMapper<CompilerArguments, ModulesPathes> _mapper;
        private readonly ICompiler _compiler;

        public CompilerProgram(
            ICommandLineArgumentsParser<CompilerArguments> commandLineArgumentsParser,
            IDataMapper<CompilerArguments, ModulesPathes> mapper,
            ICompiler compiler)
        {
            _commandLineArgumentsParser = commandLineArgumentsParser;
            _mapper = mapper;
            _compiler = compiler;
        }

        public void Start(IEnumerable<string> args)
        {
            var arguments = _commandLineArgumentsParser.Parse(args);
            var pathes = _mapper.Map(arguments);
            _compiler.Compile(pathes);
        }
    }
}