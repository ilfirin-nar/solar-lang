using Solar.Domain.Grammar.GlobalStateObjects;

namespace Solar.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes
{
    public interface ILexicalTokenType : ITokenType
    {
        bool IsMatch(string lexeme);
    }
}