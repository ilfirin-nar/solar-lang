using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.ValueObjects
{
    public class Lexem : IValueObject
    {
        public Lexem(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public int Length => Value.Length;
    }
}