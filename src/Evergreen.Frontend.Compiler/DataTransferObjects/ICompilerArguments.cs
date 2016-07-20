using System.Collections.Generic;
using Photosphere.Console.Arguments.DataTransferObjects;

namespace Evergreen.Frontend.Compiler.DataTransferObjects
{
    internal interface ICompilerArguments : ICommandLineArguments
    {
        IReadOnlyList<string> ModulesPathes { get; }

        bool ShowHelp { get; }
    }
}