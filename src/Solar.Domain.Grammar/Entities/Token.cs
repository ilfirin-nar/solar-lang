using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes;
using Solar.Domain.Grammar.ValueObjects;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Entities
{
    public class Token : IAggregationRoot
    {
        public Token(Lexem lexem, ITokenType type)
        {
            Lexem = lexem;
            Type = type;
        }

        public Lexem Lexem { get; private set; }

        public ITokenType Type { get; private set; }
    }
}