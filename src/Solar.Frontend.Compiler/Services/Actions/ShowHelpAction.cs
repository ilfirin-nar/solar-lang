using System;
using Solar.Frontend.Compiler.DataTransferObjects;

namespace Solar.Frontend.Compiler.Services.Actions
{
    internal class ShowHelpAction : ICommandLineAction
    {
        public void Action(CompilerArguments arguments)
        {
            Console.WriteLine("It's a help!");
        }
    }
}