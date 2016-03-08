using System.Collections.Generic;
using Solar.Infrastructure.Console.DataTransferObjects;

namespace Solar.Frontend.Compiler.DataTransferObjects
{
    public class CompilerArguments : ICommandLineArguments
    {
        public IList<string> ModulesPathes { get; set; }
    }
}