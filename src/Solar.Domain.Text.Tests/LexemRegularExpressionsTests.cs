using System.Linq;
using System.Text.RegularExpressions;
using Solar.Infrastructure.Common.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Solar.Domain.Text.Tests
{
    public class LexemRegularExpressionsTests
    {
        private readonly ITestOutputHelper _output;

        public LexemRegularExpressionsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        internal void CheckConsistenceOfAllRegex_Consistent()
        {
            var regexFields = typeof (LexemRegularExpressions).GetFields().ToList();
            var testMethods = typeof(LexemRegularExpressionsTests).GetStaticMethods().Where(m => m.Name.EndsWith("_IsMatch")).ToList();
            foreach (var testMethod in testMethods)
            {
                var testCases = testMethod.CustomAttributes.Where(a => a.AttributeType == typeof(InlineDataAttribute)).ToList();
                var testMethodRegexName = testMethod.Name.Split('_').First();
                foreach (var regexFieldInfo in regexFields.Where(f => f.Name != testMethodRegexName))
                {
                    var regex = (Regex) regexFieldInfo.GetValue(null);
                    foreach (var value in testCases.Select(testCase => ((dynamic)testCase.ConstructorArguments.First().Value)[0].Value))
                    {
                        var isMatch = regex.IsMatch(value);
                        var resultString = isMatch ? "Is match! It's very bad!" : "Isn't match. Good."; 
                        _output.WriteLine($"Test method regex name: `{testMethodRegexName}`\nRegex name: {regexFieldInfo.Name}\nTest case: `{value}`\nResult: {resultString}\n");
                        Assert.False(isMatch);
                    }
                }
            }
        }

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