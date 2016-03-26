using Solar.Domain.Grammar.EntityFactories.RawData;
using Solar.Domain.Grammar.Lexis.Services;

namespace Solar.Domain.Analysis.Lexical.Services.Parsing
{
    internal class TokenTypeClarifier : ITokenTypeClarifier
    {
        private readonly ILexicalTokenTypeRecognizer _lexicalTokenTypeRecognizer;

        public TokenTypeClarifier(ILexicalTokenTypeRecognizer lexicalTokenTypeRecognizer)
        {
            _lexicalTokenTypeRecognizer = lexicalTokenTypeRecognizer;
        }

        public bool TryToClarifyTokenType(string checkedLexeme, TokenRawData tokenRawData)
        {
            var clarifyedTokenType = _lexicalTokenTypeRecognizer.ClarifyTokenType(checkedLexeme, tokenRawData.TokenType);
            if (clarifyedTokenType == tokenRawData.TokenType)
            {
                return false;
            }
            tokenRawData.TokenType = clarifyedTokenType;
            return true;
        }
    }
}