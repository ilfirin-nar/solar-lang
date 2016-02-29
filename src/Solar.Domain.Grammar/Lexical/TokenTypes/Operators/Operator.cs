using Solar.Infrastructure.Common.Constants;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Operators
{
    public abstract class Operator : TokenTypeBase, ITokenType
    {
        protected override string TokenRegexPatter => RegexPatterns.NonDigitStartIdentifier;
    }
}