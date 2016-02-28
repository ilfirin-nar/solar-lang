using System;
using System.Collections.Generic;
using Solar.Domain.Analysis.LexicalAnalysis.ValueObjects;
using Solar.Domain.Grammar.Enums;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexicalAnalysis.Entities
{
    internal class Token : IAggregationRoot
    {
        public Token()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public Lexem Lexem { get; set; }

        public TokenType Type { get; set; }

        public IList<TokenAttribute> Attributes { get; set; }
    }
}