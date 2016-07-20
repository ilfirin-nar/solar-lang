using System.Text.RegularExpressions;

namespace Evergreen.Domain.Grammar.Lexis.Static
{
    public static class LexemesRegularExpressions
    {
        public static readonly Regex Space = new Regex(@"^ $");

        public static readonly Regex Indent = new Regex(@"^  $");

        public static readonly Regex NewLine = new Regex(@"^\n\r$");

        public static readonly Regex LeftParenthesis = new Regex(@"^\($");

        public static readonly Regex RightParenthesis = new Regex(@"^\)$");

        public static readonly Regex LeftSquareBracket = new Regex(@"^\[$");

        public static readonly Regex RightSquareBracket = new Regex(@"^\]$");

        public static readonly Regex LowerCaseWord = new Regex(@"^[a-z]+$");

        public static readonly Regex WordStartedWithCapitalChar = new Regex(@"^([A-Z])([a-zA-Z0-9])*$");

        public static readonly Regex WordStartedWithNonCapitalChar = new Regex(@"^([a-z])([a-zA-Z0-9])*$");

        public static readonly Regex LessThen = new Regex(@"^<$");

        public static readonly Regex GreaterThen = new Regex(@"^>$");

        public static readonly Regex LeftArrow = new Regex(@"^<-$");

        public static readonly Regex Addition = new Regex(@"^\+$");

        public static readonly Regex Substraction = new Regex(@"^\-$");

        public static readonly Regex Multiply = new Regex(@"^\*$");

        public static readonly Regex Division = new Regex(@"^\/$");
    }
}