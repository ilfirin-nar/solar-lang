using System.Collections.Generic;
using System.Linq;
using Solar.Domain.Grammar.Lexical.Services.Exceptions;
using Solar.Domain.Grammar.Lexical.TokenTypes;

namespace Solar.Domain.Grammar.Lexical.Services
{
    internal class TokenTypeRecognizer : ITokenTypeRecognizer
    {
        private readonly IReadOnlyList<ITokenType> _tokenTypes;

        public TokenTypeRecognizer(IReadOnlyList<ITokenType> tokenTypes)
        {
            _tokenTypes = tokenTypes;
        }

        public ITokenType Recognize(string lexeme)
        {
            foreach (var tokenType in _tokenTypes.Where(t => t.CharacteristicRegex.IsMatch(lexeme)))
            {
                return tokenType;
            }
            throw new UnrecognizedTokenException(lexeme);
        }

        public bool CheckTokenType(string lexeme, ITokenType tokenType)
        {
            return tokenType.CharacteristicRegex.IsMatch(lexeme);
        }
    }
}