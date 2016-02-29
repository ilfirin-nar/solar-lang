using Solar.Infrastructure.Common.Constants;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Whitespaces
{
    public class Whitespace : TokenTypeBase, ITokenType
    {
        protected override string TokenRegexPatter => RegexPatterns.NonDigitStartIdentifier;
    }
}