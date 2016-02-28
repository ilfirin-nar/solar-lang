using System.Collections.Generic;
using Solar.Domain.Analysis.LexecalAnalysis.Entities;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Analysis.LexecalAnalysis
{
    internal class LexicalAnalyzer : ILexicalAnalyzer
    {
        private readonly IEntityFactory<Token> _tokenFactory;

        public LexicalAnalyzer(IEntityFactory<Token> tokenFactory)
        {
            _tokenFactory = tokenFactory;
        }

        public IList<Token> Analyse(string content)
        {
            foreach (var character in content)
            {
                throw new System.NotImplementedException();
            }
            return null;
        }
    }
}