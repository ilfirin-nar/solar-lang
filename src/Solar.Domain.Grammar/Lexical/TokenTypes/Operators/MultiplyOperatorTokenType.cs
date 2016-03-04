using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Lexemes;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Operators
{
    public class MultiplyOperatorTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemeRegularExpressions.Multiply;
    }
}