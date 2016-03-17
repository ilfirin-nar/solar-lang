using System.Collections.Generic;
using Solar.Infrastructure.Console.Arguments.Attributes;

namespace Solar.Frontend.Compiler.DataTransferObjects
{
    internal class CompilerArguments : ICompilerArguments
    {
        [ConsoleOption("f")]
        public IReadOnlyList<string> ModulesPathes { get; set; }

        [ConsoleOption("h")]
        public bool ShowHelp { get; set; }
    }
}