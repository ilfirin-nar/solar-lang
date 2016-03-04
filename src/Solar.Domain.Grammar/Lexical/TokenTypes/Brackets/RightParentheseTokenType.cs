using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Lexemes;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Brackets
{
    public class RightParentheseTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemesRegularExpressions.RightParenthese;
    }
}