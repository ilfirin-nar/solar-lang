using System.Collections.Generic;
using Solar.Infrastructure.Console.Arguments.Attributes;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Solar.Frontend.Compiler.DataTransferObjects
{
    public class CompilerArguments : ICommandLineArguments
    {
        [ConsoleOption("f")]
        public IList<string> ModulesPathes { get; set; }

        [ConsoleOption("h")]
        public bool ShowHelp { get; set; }
    }
}