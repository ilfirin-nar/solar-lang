using Solar.Domain.Grammar.GlobalStateObjects;

namespace Solar.Domain.Grammar.Syntax.GlobalStateObjects.TokenTypes.Statements
{
    public interface IStatementTokenType : ISyntaxTokenType
    {
        bool IsMatch(ITokenType tokenType);
    }
}