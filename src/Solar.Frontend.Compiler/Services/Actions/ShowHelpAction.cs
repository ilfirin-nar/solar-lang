using System;
using Solar.Frontend.Compiler.DataTransferObjects;
using Solar.Infrastructure.Console.Actions;

namespace Solar.Frontend.Compiler.Services.Actions
{
    internal class ShowHelpAction : ICommandLineAction<ICompilerArguments>
    {
        public void Action(ICompilerArguments arguments)
        {
            Console.WriteLine("It's a help!");
        }
    }
}