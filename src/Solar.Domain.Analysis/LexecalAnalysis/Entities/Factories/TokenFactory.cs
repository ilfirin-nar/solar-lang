using System.Collections.Generic;
using LightInject;
using Solar.Domain.Analysis.LexecalAnalysis.ValueObjects;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexecalAnalysis.Entities.Factories
{
    internal class TokenFactory : IEntityFactory<Token>
    {
        public Token Produce()
        {
            return new Token
            {
                Lexem = new Lexem("something"),
                Attributes = ProduceTokenAttributes()
            };
        }

        public IEnumerable<Token> Manufacture()
        {
            throw new System.NotImplementedException();
        }

        private static IList<TokenAttribute> ProduceTokenAttributes()
        {
            return new List<TokenAttribute>();
        }
    }
}