using Solar.Domain.Grammar.Lexical.TokenTypes;
using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Lexical.Services
{
    public interface ITokenTypeRecognizer : IDomainService
    {
        ITokenType Recognize(string lexeme);

        bool CheckTokenType(string lexeme, ITokenType tokenType);
    }
}