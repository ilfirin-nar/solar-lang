using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes;
using Evergreen.Infrastructure.Common.Interfaces.DomainLayer;

namespace Evergreen.Domain.Grammar.Lexis.Services
{
    public interface ILexicalTokenTypeRecognizer : IDomainService
    {
        ILexicalTokenType Recognize(string lexeme);

        ILexicalTokenType ClarifyTokenType(string lexeme, ILexicalTokenType currentTokenType);

        bool IsMatch(string lexeme, ILexicalTokenType tokenType);
    }
}