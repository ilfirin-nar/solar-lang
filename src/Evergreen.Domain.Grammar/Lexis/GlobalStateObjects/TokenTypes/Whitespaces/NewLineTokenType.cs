using System.Text.RegularExpressions;
using Evergreen.Domain.Grammar.Lexis.Static;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Whitespaces
{
    public class NewLineTokenType : LexicalTokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.NewLine;
    }
}