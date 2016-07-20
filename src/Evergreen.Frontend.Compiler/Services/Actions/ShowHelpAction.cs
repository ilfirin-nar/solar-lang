using System;
using Evergreen.Frontend.Compiler.DataTransferObjects;
using Photosphere.Console.Actions;

namespace Evergreen.Frontend.Compiler.Services.Actions
{
    internal class ShowHelpAction : ICommandLineAction<ICompilerArguments>
    {
        public void Action(ICompilerArguments arguments)
        {
            Console.WriteLine("It's a help!");
        }
    }
}