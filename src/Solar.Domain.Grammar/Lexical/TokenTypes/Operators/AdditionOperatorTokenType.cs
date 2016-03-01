using System.Text.RegularExpressions;
using Solar.Domain.Text;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Operators
{
    public class AdditionOperatorTokenType : ITokenType
    {
        public Regex CharacteristicRegex => RegularExpressions.Addition;
    }
}