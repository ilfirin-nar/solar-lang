using System.Text.RegularExpressions;
using Solar.Domain.Text;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Operators
{
    public class DivisionOperatorTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemRegularExpressions.Division;
    }
}