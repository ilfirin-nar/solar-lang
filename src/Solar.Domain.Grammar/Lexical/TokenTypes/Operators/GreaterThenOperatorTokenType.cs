using System.Text.RegularExpressions;
using Solar.Domain.Text;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Operators
{
    public class GreaterThenOperatorTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemRegularExpressions.GreaterThen;
    }
}