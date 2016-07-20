using System.Collections.Generic;
using Evergreen.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Evergreen.Frontend.Compiler.DataTransferObjects
{
    internal interface ICompilerArguments : ICommandLineArguments
    {
        IReadOnlyList<string> ModulesPathes { get; }

        bool ShowHelp { get; }
    }
}