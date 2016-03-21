using System.Linq;
using Solar.Domain.Grammar.Lexis.Directories;
using Solar.Domain.Grammar.Lexis.Services.Exceptions;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes;
using Solar.Infrastructure.Common.Extensions;

namespace Solar.Domain.Grammar.Lexis.Services
{
    internal class TokenTypeRecognizer : ITokenTypeRecognizer
    {
        private readonly ITokenTypesDirectory _tokenTypesDirectory;

        public TokenTypeRecognizer(ITokenTypesDirectory tokenTypesDirectory)
        {
            _tokenTypesDirectory = tokenTypesDirectory;
        }

        public ITokenType Recognize(string lexeme)
        {
            foreach (var tokenType in _tokenTypesDirectory.TokenTypes.Where(t => t.IsMatch(lexeme)))
            {
                return tokenType;
            }
            throw new UnrecognizedTokenException(lexeme);
        }

        public ITokenType ClarifyTokenType(string lexeme, ITokenType currentTokenType)
        {
            var tokenTypesExceptCurrent = _tokenTypesDirectory.TokenTypes.ExceptItmes(currentTokenType);
            var newTokenType = tokenTypesExceptCurrent.FirstOrDefault(t => t.IsMatch(lexeme));
            return newTokenType ?? currentTokenType;
        }

        public bool IsMatch(string lexeme, ITokenType tokenType)
        {
            return tokenType.IsMatch(lexeme);
        }
    }
}