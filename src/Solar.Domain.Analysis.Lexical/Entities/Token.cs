using Solar.Domain.Analysis.Lexical.ValueObjects;
using Solar.Domain.Grammar.Lexical.TokenTypes;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.Lexical.Entities
{
    internal class Token : IAggregationRoot
    {
        public Lexem Lexem { get; set; }

        public ITokenType Type { get; set; }
    }
}