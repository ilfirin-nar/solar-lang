using Solar.Domain.Grammar.EntityFactories.RawData;
using Solar.Domain.Grammar.Lexis.Services;

namespace Solar.Domain.Analysis.Lexical.Services.Parsing
{
    internal class TokenTypeClarifier : ITokenTypeClarifier
    {
        private readonly ITokenTypeRecognizer _tokenTypeRecognizer;

        public TokenTypeClarifier(ITokenTypeRecognizer tokenTypeRecognizer)
        {
            _tokenTypeRecognizer = tokenTypeRecognizer;
        }

        public bool TryToClarifyTokenType(string checkedLexeme, TokenRawData tokenRawData)
        {
            var clarifyedTokenType = _tokenTypeRecognizer.ClarifyTokenType(checkedLexeme, tokenRawData.TokenType);
            if (clarifyedTokenType == tokenRawData.TokenType)
            {
                return false;
            }
            tokenRawData.TokenType = clarifyedTokenType;
            return true;
        }
    }
}