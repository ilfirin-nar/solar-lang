using System.Linq;
using Solar.Domain.Grammar.Lexical.Directories;
using Solar.Domain.Grammar.Lexical.Services.Exceptions;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes;
using Solar.Infrastructure.Common.Extensions;

namespace Solar.Domain.Grammar.Lexical.Services
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
            var tokemTypesExceptCurrent = _tokenTypesDirectory.TokenTypes.ExceptItmes(currentTokenType);
            var newTokenType = tokemTypesExceptCurrent.FirstOrDefault(t => t.IsMatch(lexeme));
            return newTokenType ?? currentTokenType;
        }

        public bool Check(string lexeme, ITokenType tokenType)
        {
            return tokenType.IsMatch(lexeme);
        }
    }
}