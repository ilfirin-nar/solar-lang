using Solar.Domain.Analysis.Lexical.ValueObjects;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Lexical.Entities
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