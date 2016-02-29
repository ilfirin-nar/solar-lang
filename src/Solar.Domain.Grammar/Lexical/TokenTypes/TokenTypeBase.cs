using System.Text.RegularExpressions;

namespace Solar.Domain.Grammar.Lexical.TokenTypes
{
    public abstract class TokenTypeBase : ITokenType
    {
        protected abstract string TokenRegexPatter { get; }

        public Regex CharacteristicRegex => new Regex(TokenRegexPatter);
    }
}