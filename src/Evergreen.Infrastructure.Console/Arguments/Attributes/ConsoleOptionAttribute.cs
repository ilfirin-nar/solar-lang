using System;

namespace Evergreen.Infrastructure.Console.Arguments.Attributes
{
    public class ConsoleOptionAttribute : Attribute
    {
        public string Option { get; set; }

        public Type BoundedActionType { get; set; }

        public bool AllowMultiple { get; set; }

        public bool IsRequired { get; set; }
    }
}