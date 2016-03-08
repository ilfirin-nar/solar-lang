using System.Collections.Generic;
using Solar.Infrastructure.Console.Arguments.Attributes;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Solar.Frontend.Compiler.DataTransferObjects
{
    public class CompilerArguments : ICommandLineArguments
    {
        [ConsoleOption("f", IsRequired = true)]
        public IList<string> ModulesPathes { get; set; }
    }
}