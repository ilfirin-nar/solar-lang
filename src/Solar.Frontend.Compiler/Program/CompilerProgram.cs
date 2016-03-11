using System.Collections.Generic;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Frontend.Compiler.Services;
using Solar.Infrastructure.Config.Services;
using Solar.Infrastructure.Console.Arguments.Services;

namespace Solar.Frontend.Compiler.Program
{
    internal class CompilerProgram : ICompilerProgram
    {
        private const string DefaultConfigPath = "config.json";
        private readonly ICommandLineArgumentsParser<CompilerArguments> _commandLineArgumentsParser;
        private readonly IConfigurator _configurator;
        private readonly ICommandLineActionSelector _commandLineActionSelector;

        public CompilerProgram(
            ICommandLineArgumentsParser<CompilerArguments> commandLineArgumentsParser,
            IConfigurator configurator,
            ICommandLineActionSelector commandLineActionSelector)
        {
            _commandLineArgumentsParser = commandLineArgumentsParser;
            _configurator = configurator;
            _commandLineActionSelector = commandLineActionSelector;
        }

        public void Start(IEnumerable<string> args)
        {
            var arguments = _commandLineArgumentsParser.Parse(args);
            _configurator.Configure(DefaultConfigPath);
            _commandLineActionSelector.Select(arguments)(arguments);
        }
    }
}