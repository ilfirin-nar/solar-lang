using System.Text.RegularExpressions;
using Solar.Domain.Text;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Brackets
{
    public class LeftParentheseTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemRegularExpressions.LeftParenthese;
    }
}