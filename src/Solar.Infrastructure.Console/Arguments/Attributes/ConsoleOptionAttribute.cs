using System;

namespace Solar.Infrastructure.Console.Arguments.Attributes
{
    public class ConsoleOptionAttribute : Attribute
    {
        public ConsoleOptionAttribute(string option)
        {
            Option = option;
        }

        public string Option { get; set; }

        public bool AllowMultiple { get; set; }

        public bool IsRequired { get; set; }
    }
}