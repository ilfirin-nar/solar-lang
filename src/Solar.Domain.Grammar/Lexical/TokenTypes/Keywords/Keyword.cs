using Solar.Infrastructure.Common.Constants;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Keywords
{
    public class Keyword : TokenTypeBase, ITokenType
    {
        protected override string TokenRegexPatter => RegexPatterns.NonDigitStartIdentifier;
    }
}