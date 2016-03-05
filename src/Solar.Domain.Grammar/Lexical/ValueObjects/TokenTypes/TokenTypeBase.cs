using System.Text.RegularExpressions;

namespace Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes
{
    public abstract class TokenTypeBase : ITokenType
    {
        protected abstract Regex CharacteristicRegex { get; }

        public virtual bool IsMatch(string lexeme)
        {
            return CharacteristicRegex.IsMatch(lexeme);
        }
    }
}