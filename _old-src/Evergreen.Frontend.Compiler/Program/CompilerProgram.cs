using System;
using System.Collections.Generic;
using Evergreen.Frontend.Compiler.DataTransferObjects;
using Evergreen.Infrastructure.Common.Interfaces.FrontendLayer;
using Evergreen.Infrastructure.Configuration.Services;
using Evergreen.Infrastructure.ErrorHandling.Services;
using Photosphere.Console.Actions.Services;
using Photosphere.Console.Arguments.Services;

namespace Evergreen.Frontend.Compiler.Program
{
    internal class CompilerProgram : IConsoleProgram
    {
        private readonly ICommandLineArgumentsParser<CompilerArguments> _commandLineArgumentsParser;
        private readonly ICommandLineActionSelector<CompilerArguments> _commandLineActionSelector;
        private readonly IErrorHandler _errorHandler;

        public CompilerProgram(
            IConfigurator configurator,
            ICommandLineArgumentsParser<CompilerArguments> commandLineArgumentsParser,
            ICommandLineActionSelector<CompilerArguments> commandLineActionSelector,
            IErrorHandler errorHandler)
        {
            configurator.Configure();
            _commandLineArgumentsParser = commandLineArgumentsParser;
            _commandLineActionSelector = commandLineActionSelector;
            _errorHandler = errorHandler;
        }

        public void Start(IEnumerable<string> args)
        {
            try
            {
                var arguments = _commandLineArgumentsParser.Parse(args);
                _commandLineActionSelector.Select(arguments)(arguments);
            }
            catch (Exception exception)
            {
                _errorHandler.Handle(exception);
            }
        }
    }
}