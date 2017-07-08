using System.Collections.Generic;
using Evergreen.Frontend.Compiler.Services.Actions;
using Photosphere.Console.Arguments.Attributes;

namespace Evergreen.Frontend.Compiler.DataTransferObjects
{
    internal class CompilerArguments : ICompilerArguments
    {
        [ConsoleOption(Option = "f", BoundedActionType = typeof (CompileAction))]
        public IReadOnlyList<string> ModulesPathes { get; set; }

        [ConsoleOption(Option = "h", BoundedActionType = typeof(ShowHelpAction))]
        public bool ShowHelp { get; set; }
    }
}