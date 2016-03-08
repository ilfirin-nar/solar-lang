using System;

namespace Solar.Infrastructure.Console.Attributes
{
    public class ConsoleOptionAttribute : Attribute
    {
        private const ushort DefaultOptionsCount = 1;

        public ConsoleOptionAttribute(string option)
        {
            Option = option;
            OptionsCount = DefaultOptionsCount;
        }

        public string Option { get; set; }

        public ushort OptionsCount { get; set; }

        public bool IsRequired { get; set; }
    }
}