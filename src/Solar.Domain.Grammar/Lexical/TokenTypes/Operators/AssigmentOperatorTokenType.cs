using System.Text.RegularExpressions;
using Solar.Domain.Text;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Operators
{
    public class AssigmentOperatorTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemRegularExpressions.LeftArrow;
    }
}