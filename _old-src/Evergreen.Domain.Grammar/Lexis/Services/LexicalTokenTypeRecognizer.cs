using System.Linq;
using Evergreen.Domain.Grammar.Lexis.Directories;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes;
using Evergreen.Domain.Grammar.Lexis.Services.Exceptions;
using Evergreen.Infrastructure.Common.Extensions;

namespace Evergreen.Domain.Grammar.Lexis.Services
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
            var tokenTypesExceptCurrent = _lexicalTokenTypesDirectory.LexicalTokenTypes.ExceptItems(currentTokenType);
            var newTokenType = tokenTypesExceptCurrent.FirstOrDefault(t => t.IsMatch(lexeme));
            return newTokenType ?? currentTokenType;
        }

        public bool IsMatch(string lexeme, ILexicalTokenType tokenType)
        {
            return tokenType.IsMatch(lexeme);
        }
    }
}