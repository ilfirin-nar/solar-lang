using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Lexical.Services
{
    public interface ITokenTypeRecognizer : IDomainService
    {
        ITokenType Recognize(string lexeme);

        ITokenType ClarifyTokenType(string lexeme, ITokenType currentTokenType);

        bool Check(string lexeme, ITokenType tokenType);
    }
}