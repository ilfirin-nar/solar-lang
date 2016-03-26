using System.Linq;
using Solar.Domain.Grammar.Lexis.Directories;
using Solar.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes;
using Solar.Domain.Grammar.Lexis.Services.Exceptions;
using Solar.Infrastructure.Common.Extensions;

namespace Solar.Domain.Grammar.Lexis.Services
{
    internal class LexicalTokenTypeRecognizer : ILexicalTokenTypeRecognizer
    {
        private readonly ILexicalTokenTypesDirectory _lexicalTokenTypesDirectory;

        public LexicalTokenTypeRecognizer(ILexicalTokenTypesDirectory lexicalTokenTypesDirectory)
        {
            _lexicalTokenTypesDirectory = lexicalTokenTypesDirectory;
        }

        public ILexicalTokenType Recognize(string lexeme)
        {
            foreach (var tokenType in _lexicalTokenTypesDirectory.LexicalTokenTypes.Where(t => t.IsMatch(lexeme)))
            {
                return tokenType;
            }
            throw new UnrecognizedTokenException(lexeme);
        }

        public ILexicalTokenType ClarifyTokenType(string lexeme, ILexicalTokenType currentTokenType)
        {
            var tokenTypesExceptCurrent = _lexicalTokenTypesDirectory.LexicalTokenTypes.ExceptItmes(currentTokenType);
            var newTokenType = tokenTypesExceptCurrent.FirstOrDefault(t => t.IsMatch(lexeme));
            return newTokenType ?? currentTokenType;
        }

        public bool IsMatch(string lexeme, ILexicalTokenType tokenType)
        {
            return tokenType.IsMatch(lexeme);
        }
    }
}