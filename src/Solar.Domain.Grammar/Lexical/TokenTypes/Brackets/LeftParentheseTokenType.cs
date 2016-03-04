using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Lexemes;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Brackets
{
    public class LeftParentheseTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemeRegularExpressions.LeftParenthese;
    }
}