using System;
using System.Collections.Generic;
using Solar.Domain.Analysis.LexecalAnalysis.ValueObjects;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexecalAnalysis.Entities
{
    internal class Token : IEntity
    {
        public Token()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public Lexem Lexem { get; set; }

        public IList<TokenAttribute> Attributes { get; set; }
    }
}