using Xunit;

namespace Solar.Domain.Text.Tests
{
    public class LexemeRegularExpressionsTests
    {
        [Theory]
        [InlineData(" ")]
        internal void Space_IsMatch(string value)
        {
            Assert.True(LexemRegularExpressions.Space.IsMatch(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(" _")]
        [InlineData("d ")]
        [InlineData("ef")]
        internal void Space_IsNotMatch(string value)
        {
            Assert.False(LexemRegularExpressions.Space.IsMatch(value));
        }

        [Theory]
        [InlineData("  ")]
        internal void Indent_IsMatch(string value)
        {
            Assert.True(LexemRegularExpressions.Indent.IsMatch(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("d  ")]
        [InlineData("  d")]
        [InlineData("ef")]
        internal void Indent_IsNotMatch(string value)
        {
            Assert.False(LexemRegularExpressions.Indent.IsMatch(value));
        }

        [Theory]
        [InlineData("\n\r")]
        internal void NewLine_IsMatch(string value)
        {
            Assert.True(LexemRegularExpressions.NewLine.IsMatch(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("(")]
        [InlineData("\r\n")]
        [InlineData("\n\r ")]
        [InlineData(" \n\r")]
        [InlineData(" \n\r ")]
        [InlineData("wg2g2\n\r2g23g2")]
        internal void NewLine_IsNotMatch(string value)
        {
            Assert.False(LexemRegularExpressions.NewLine.IsMatch(value));
        }

        [Theory]
        [InlineData("F")]
        [InlineData("FooBar")]
        [InlineData("Foo2bar")]
        [InlineData("Foo2Bar")]
        [InlineData("FFFooBar")]
        internal void WordStartedWithCapitalChar_IsMatch(string value)
        {
            Assert.True(LexemRegularExpressions.WordStartedWithCapitalChar.IsMatch(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("f")]
        [InlineData("")]
        [InlineData("fooBar")]
        [InlineData("3fooBar")]
        [InlineData("3FooBar")]
        [InlineData(" FooBar")]
        [InlineData("FooBar ")]
        [InlineData(" FooBar ")]
        [InlineData("Foo_Bar")]
        [InlineData("Foo/Bar")]
        internal void WordStartedWithCapitalChar_IsNotMatch(string value)
        {
            Assert.False(LexemRegularExpressions.WordStartedWithCapitalChar.IsMatch(value));
        }

        [Theory]
        [InlineData("f")]
        [InlineData("fooBar")]
        [InlineData("foo2bar")]
        [InlineData("foo2Bar")]
        [InlineData("fFFooBar")]
        internal void WordStartedWithNonCapitalChar_IsMatch(string value)
        {
            Assert.True(LexemRegularExpressions.WordStartedWithNonCapitalChar.IsMatch(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("F")]
        [InlineData("")]
        [InlineData("FooBar")]
        [InlineData("3fooBar")]
        [InlineData("3fooBar")]
        [InlineData(" fooBar")]
        [InlineData("fooBar ")]
        [InlineData(" fooBar ")]
        [InlineData("foo_bar")]
        [InlineData("Foo/Bar")]
        internal void WordStartedWithNonCapitalChar_IsNotMatch(string value)
        {
            Assert.False(LexemRegularExpressions.WordStartedWithNonCapitalChar.IsMatch(value));
        }

        [Theory]
        [InlineData(">")]
        internal void GreaterThen_IsMatch(string value)
        {
            Assert.True(LexemRegularExpressions.GreaterThen.IsMatch(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData("> ")]
        [InlineData(" >")]
        [InlineData(">>")]
        [InlineData(">_")]
        internal void GreaterThen_IsNotMatch(string value)
        {
            Assert.False(LexemRegularExpressions.GreaterThen.IsMatch(value));
        }

        [Theory]
        [InlineData("<")]
        internal void LessThen_IsMatch(string value)
        {
            Assert.True(LexemRegularExpressions.LessThen.IsMatch(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData("< ")]
        [InlineData(" <")]
        [InlineData("<<")]
        [InlineData("<-")]
        internal void LessThen_IsNotMatch(string value)
        {
            Assert.False(LexemRegularExpressions.LessThen.IsMatch(value));
        }

        [Theory]
        [InlineData("<-")]
        internal void LeftArrow_IsMatch(string value)
        {
            Assert.True(LexemRegularExpressions.LeftArrow.IsMatch(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData("< ")]
        [InlineData(" <")]
        [InlineData("<- ")]
        [InlineData(" <-")]
        [InlineData("<-<")]
        [InlineData("<<")]
        internal void LeftArrow_IsNotMatch(string value)
        {
            Assert.False(LexemRegularExpressions.LeftArrow.IsMatch(value));
        }
    }
}