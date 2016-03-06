using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.ValueObjects
{
    public class Lexeme : IValueObject
    {
        public Lexeme(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public int Length => Value.Length;
    }
}