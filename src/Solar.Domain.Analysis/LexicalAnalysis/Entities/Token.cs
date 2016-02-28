using Solar.Domain.Analysis.LexicalAnalysis.ValueObjects;
using Solar.Domain.Grammar.Lexical;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexicalAnalysis.Entities
{
    internal class Token : IAggregationRoot
    {
        public Lexem Lexem { get; set; }

        public ITokenType Type { get; set; }
    }
}