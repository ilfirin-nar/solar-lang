using System.Collections.Generic;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Solar.Frontend.Compiler.DataTransferObjects
{
    internal interface ICompilerArguments : ICommandLineArguments
    {
        IReadOnlyList<string> ModulesPathes { get; }

        bool ShowHelp { get; }
    }
}