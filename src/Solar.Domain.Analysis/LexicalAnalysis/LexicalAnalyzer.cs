using System.Collections.Generic;
using Solar.Domain.Analysis.LexicalAnalysis.Entities;
using Solar.Domain.Analysis.LexicalAnalysis.EntityFactories;

namespace Solar.Domain.Analysis.LexicalAnalysis
{
    internal class LexicalAnalyzer : ILexicalAnalyzer
    {
        private readonly ITokenFactory _tokenFactory;

        public LexicalAnalyzer(ITokenFactory tokenFactory)
        {
            _tokenFactory = tokenFactory;
        }

        public IList<Token> Analyse(string content)
        {
            throw new System.NotImplementedException();
        }
    }
}