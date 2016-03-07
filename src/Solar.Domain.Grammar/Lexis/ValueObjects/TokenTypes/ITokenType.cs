using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes
{
    public interface ITokenType : IValueObject
    {
        bool IsMatch(string lexeme);
    }
}