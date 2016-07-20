using Evergreen.Domain.Grammar.GlobalStateObjects;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes
{
    public interface ILexicalTokenType : ITokenType
    {
        bool IsMatch(string lexeme);
    }
}