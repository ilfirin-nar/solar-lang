using System.Collections.Generic;
using Solar.Infrastructure.Console.Arguments.Attributes;
using Solar.Infrastructure.Console.Arguments.DataTransferObjects;

namespace Solar.Infrastructure.Console.Tests.Arguments.Services.TestDataTransferObjects
{
    public class TestCommandLineArguments : ICommandLineArguments
    {
        public TestCommandLineArguments()
        {
            Foos = new List<string>();
        }

        [ConsoleOption("f")]
        public string Foo { get; set; }

        [ConsoleOption("fs", AllowMultiple = true)]
        public IList<string> Foos { get; set; }

        [ConsoleOption("b")]
        public string Bar { get; set; }

        [ConsoleOption("r", IsRequired = true)]
        public string Rock { get; set; }
    }
}