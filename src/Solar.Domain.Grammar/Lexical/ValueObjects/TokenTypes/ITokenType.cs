using Solar.Infrastructure.Common.Interfaces.DomainLayer;

namespace Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes
{
    public interface ITokenType : IValueObject
    {
        bool IsMatch(string lexeme);
    }
}