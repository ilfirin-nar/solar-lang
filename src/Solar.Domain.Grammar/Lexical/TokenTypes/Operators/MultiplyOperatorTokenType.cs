using System.Text.RegularExpressions;
using Solar.Domain.Text;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Operators
{
    public class MultiplyOperatorTokenType : ITokenType
    {
        public Regex CharacteristicRegex => RegularExpressions.Multiply;
    }
}