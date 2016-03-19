using System.Collections.Generic;
using Solar.Frontend.Compiler.Services.Actions;
using Solar.Infrastructure.Console.Arguments.Attributes;

namespace Solar.Frontend.Compiler.DataTransferObjects
{
    internal class CompilerArguments : ICompilerArguments
    {
        [ConsoleOption(Option = "f", BoundedActionType = typeof (CompileAction))]
        public IReadOnlyList<string> ModulesPathes { get; set; }

        [ConsoleOption(Option = "h", BoundedActionType = typeof(ShowHelpAction))]
        public bool ShowHelp { get; set; }
    }
}