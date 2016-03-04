using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Lexemes;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Whitespaces
{
    public class NewLineTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemesRegularExpressions.NewLine;
    }
}