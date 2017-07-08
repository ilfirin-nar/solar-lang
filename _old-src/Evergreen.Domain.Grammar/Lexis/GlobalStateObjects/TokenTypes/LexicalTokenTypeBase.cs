using System.Text.RegularExpressions;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes
{
    public abstract class LexicalTokenTypeBase : ILexicalTokenType
    {
        protected abstract Regex CharacteristicRegex { get; }

        public virtual bool IsMatch(string lexeme)
        {
            return CharacteristicRegex.IsMatch(lexeme);
        }
    }
}