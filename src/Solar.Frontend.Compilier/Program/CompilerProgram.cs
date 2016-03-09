using System.Collections.Generic;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Frontend.Compiler.Services;
using Solar.Infrastructure.Console.Arguments.Services;

namespace Solar.Frontend.Compiler.Program
{
    internal class CompilerProgram : ICompilerProgram
    {
        private readonly ICommandLineArgumentsParser<CompilerArguments> _commandLineArgumentsParser;
        private readonly IActionSelector _actionSelector;

        public CompilerProgram(
            ICommandLineArgumentsParser<CompilerArguments> commandLineArgumentsParser,
            IActionSelector actionSelector)
        {
            _commandLineArgumentsParser = commandLineArgumentsParser;
            _actionSelector = actionSelector;
        }

        public void Start(IEnumerable<string> args)
        {
            var arguments = _commandLineArgumentsParser.Parse(args);
            _actionSelector.Select(arguments)(arguments);
        }
    }
}