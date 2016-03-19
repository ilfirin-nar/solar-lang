using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Static;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Whitespaces
{
    public class NewLineTokenType : TokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.NewLine;
    }
}