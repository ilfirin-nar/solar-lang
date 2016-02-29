using Solar.Infrastructure.Common.Constants;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Identifiers
{
    public class Identifier : TokenTypeBase, ITokenType
    {
        protected override string TokenRegexPatter => RegexPatterns.NonDigitStartIdentifier;
    }
}