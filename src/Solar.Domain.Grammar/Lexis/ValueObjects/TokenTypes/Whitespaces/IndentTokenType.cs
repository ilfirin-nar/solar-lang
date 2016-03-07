using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Constants;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Whitespaces
{
    public class IndentTokenType : TokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.Indent;
    }
}