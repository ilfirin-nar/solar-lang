using System.Collections.Generic;
using Evergreen.Frontend.Compiler.DataTransferObjects;
using Evergreen.Infrastructure.Configuration.Services;
using Photosphere.Console.Actions.Services;
using Photosphere.Console.Arguments.Services;

namespace Evergreen.Frontend.Compiler.Program
{
    internal class CompilerProgram : ICompilerProgram
    {
        private readonly ICommandLineArgumentsParser<CompilerArguments> _commandLineArgumentsParser;
        private readonly ICommandLineActionSelector<CompilerArguments> _commandLineActionSelector;

        public CompilerProgram(
            IConfigurator configurator,
            ICommandLineArgumentsParser<CompilerArguments> commandLineArgumentsParser,
            ICommandLineActionSelector<CompilerArguments> commandLineActionSelector)
        {
            configurator.Configure();
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