using System.Collections.Generic;
using Solar.Domain.Analysis.LexicalAnalysis.Entities;
using Solar.Domain.Analysis.LexicalAnalysis.EntityFactories;
using Solar.Domain.Analysis.LexicalAnalysis.EntityFactories.RawData;
using Solar.Domain.Grammar.Lexical;

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
            var result = new List<Token>();
            foreach (var symbol in content)
            {
                
            }
            return result;
        }

        private TokenRawData FormTokenRawData(string lexem)
        {
            var tokenType = RecognizeTokenType(lexem);
            return new TokenRawData(lexem, tokenType);
        }

        private ITokenType RecognizeTokenType(string lexem)
        {
            throw new System.NotImplementedException();
        }
    }
}