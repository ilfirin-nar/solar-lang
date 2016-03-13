using Solar.Infrastructure.Common.Interfaces.InfrastructureLayer;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes
{
    public interface ITokenType : IGlobalStateObject
    {
        bool IsMatch(string lexeme);
    }
}