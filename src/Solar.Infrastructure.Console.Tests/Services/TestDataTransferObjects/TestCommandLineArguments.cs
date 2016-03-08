using System.Collections.Generic;
using Solar.Infrastructure.Console.Attributes;
using Solar.Infrastructure.Console.DataTransferObjects;

namespace Solar.Infrastructure.Console.Tests.Services.TestDataTransferObjects
{
    public class TestCommandLineArguments : ICommandLineArguments
    {
        [ConsoleOption("f")]
        public string Foo { get; set; }

        [ConsoleOption("fs")]
        public IList<string> Foos { get; set; }

        [ConsoleOption("b")]
        public int Bar { get; set; }

        [ConsoleOption("r", IsRequired = true)]
        public bool IsRock { get; set; }
    }
}