using System.Collections.Generic;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Frontend.Compiler.Services;
using Solar.Infrastructure.Console.Arguments.Services;

namespace Solar.Frontend.Compiler.Program
{
    internal class CompilerProgram : ICompilerProgram
    {
        private readonly ICommandLineArgumentsParser<CompilerArguments> _commandLineArgumentsParser;
        private readonly ICommandLineActionSelector _commandLineActionSelector;

        public CompilerProgram(
            ICommandLineArgumentsParser<CompilerArguments> commandLineArgumentsParser,
            ICommandLineActionSelector commandLineActionSelector)
        {
            _commandLineArgumentsParser = commandLineArgumentsParser;
            _commandLineActionSelector = commandLineActionSelector;
        }

        public void Start(IEnumerable<string> args)
        {
            var arguments = _commandLineArgumentsParser.Parse(args);
            _commandLineActionSelector.Select(arguments)(arguments);
        }
    }
}