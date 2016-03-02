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
            return Recognize(lexeme, _tokenTypes);
        }

        public ITokenType ClarifyTokenType(string lexeme, ITokenType tokenType)
        {
            var tokenTypesWithoutOld = new List<ITokenType> { tokenType };
            return Recognize(lexeme, _tokenTypes.Except(tokenTypesWithoutOld));
        }

        private static ITokenType Recognize(string lexeme, IEnumerable<ITokenType> tokenTypes)
        {
            foreach (var tokenType in tokenTypes.Where(t => t.CharacteristicRegex.IsMatch(lexeme)))
            {
                return tokenType;
            }
            throw new UnrecognizedTokenException(lexeme);
        }
    }
}