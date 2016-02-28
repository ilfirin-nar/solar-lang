using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexicalAnalysis.ValueObjects
{
    internal class Lexem : IValueObject
    {
        public Lexem(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public int Length => Value.Length;
    }
}