using Solar.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Lexis.Services
{
    public interface ILexicalTokenTypeRecognizer : IDomainService
    {
        ILexicalTokenType Recognize(string lexeme);

        ILexicalTokenType ClarifyTokenType(string lexeme, ILexicalTokenType currentTokenType);

        bool IsMatch(string lexeme, ILexicalTokenType tokenType);
    }
}