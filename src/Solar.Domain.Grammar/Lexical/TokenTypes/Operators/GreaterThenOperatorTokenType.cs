using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Lexemes;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Operators
{
    public class GreaterThenOperatorTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemeRegularExpressions.GreaterThen;
    }
}