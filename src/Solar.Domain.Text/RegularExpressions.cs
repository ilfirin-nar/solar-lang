using System.Text.RegularExpressions;

namespace Solar.Domain.Text
{
    public static class RegularExpressions
    {
        public static readonly Regex Space = new Regex(@"^ $");

        public static readonly Regex Indent = new Regex(@"^  $");

        public static readonly Regex NewLine = new Regex(@"^\n\r$");

        public static readonly Regex LeftParenthese = new Regex(@"^\($");

        public static readonly Regex RightParenthese = new Regex(@"^\)$");

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