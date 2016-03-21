using Solar.Domain.Grammar.EntityFactories.RawData;
using Solar.Domain.Grammar.Lexis.Services;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes;

namespace Solar.Domain.Analysis.Lexical.Services.Parsing
{
    internal class TokenTypeClarifier : ITokenTypeClarifier
    {
        private readonly ITokenTypeRecognizer _tokenTypeRecognizer;

        public TokenTypeClarifier(ITokenTypeRecognizer tokenTypeRecognizer)
        {
            _tokenTypeRecognizer = tokenTypeRecognizer;
        }

        public bool TryToClarifyTokenType(string checkedLexeme, TokenRawData tokenRawData, char character)
        {
            var clarifyedTokenType = _tokenTypeRecognizer.ClarifyTokenType(checkedLexeme, tokenRawData.TokenType);
            if (clarifyedTokenType == tokenRawData.TokenType)
            {
                return false;
            }
            ApplyClarifyedTokenType(tokenRawData, character, clarifyedTokenType);
            return true;
        }

        private static void ApplyClarifyedTokenType(TokenRawData tokenRawData, char character, ITokenType clarifyedTokenType)
        {
            tokenRawData.Lexeme += character;
            tokenRawData.TokenType = clarifyedTokenType;
        }
    }
}