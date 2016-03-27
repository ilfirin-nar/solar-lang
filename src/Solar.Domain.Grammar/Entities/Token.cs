using Solar.Domain.Grammar.GlobalStateObjects;

namespace Solar.Domain.Grammar.Entities
{
    public class Token : IToken
    {
        public Token(string value, ITokenType type)
        {
            Value = value;
            Type = type;
        }

        public string Value { get; }

        public ITokenType Type { get; }
    }
}