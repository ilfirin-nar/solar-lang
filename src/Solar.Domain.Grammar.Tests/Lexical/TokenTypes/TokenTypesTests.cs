using LightInject.xUnit2;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Operators;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Whitespaces;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Words.Identifiers;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Words.Keywords;
using Xunit;

namespace Solar.Domain.Grammar.Tests.Lexical.TokenTypes
{
    public class TokenTypesTests
    {
        [Theory]
        [InjectData(" ")]
        internal void Space_IsMatch(SpaceTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData("  ")]
        [InjectData(" _")]
        [InjectData("d ")]
        [InjectData("ef")]
        internal void Space_IsNotMatch(SpaceTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("  ")]
        internal void Indent_IsMatch(IndentTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData(" ")]
        [InjectData("   ")]
        [InjectData("d  ")]
        [InjectData("  d")]
        [InjectData("ef")]
        internal void Indent_IsNotMatch(IndentTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("\n\r")]
        internal void NewLine_IsMatch(NewLineTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData(" ")]
        [InjectData("  ")]
        [InjectData("(")]
        [InjectData("\r\n")]
        [InjectData("\n\r ")]
        [InjectData(" \n\r")]
        [InjectData(" \n\r ")]
        [InjectData("wg2g2\n\r2g23g2")]
        internal void NewLine_IsNotMatch(NewLineTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("model")]
        internal void ModelKeyword_IsMatch(ModelKeywordTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData(" ")]
        [InjectData(" model")]
        [InjectData("model ")]
        [InjectData("m")]
        internal void ModelKeyword_IsNotMatch(ModelKeywordTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("service")]
        internal void ServiceKeyword_IsMatch(ServiceKeywordTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData(" ")]
        [InjectData(" service")]
        [InjectData("service ")]
        [InjectData("s")]
        internal void ServiceKeyword_IsNotMatch(ServiceKeywordTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("F")]
        [InjectData("FooBar")]
        [InjectData("Foo2bar")]
        [InjectData("Foo2Bar")]
        [InjectData("FFFooBar")]
        internal void TypeIdentifier_IsMatch(TypeIdentifierTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData(" ")]
        [InjectData("f")]
        [InjectData("")]
        [InjectData("fooBar")]
        [InjectData("3fooBar")]
        [InjectData("3FooBar")]
        [InjectData(" FooBar")]
        [InjectData("FooBar ")]
        [InjectData(" FooBar ")]
        [InjectData("Foo_Bar")]
        [InjectData("Foo/Bar")]
        internal void TypeIdentifier_IsNotMatch(TypeIdentifierTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("f")]
        [InjectData("fooBar")]
        [InjectData("foo2bar")]
        [InjectData("foo2Bar")]
        [InjectData("fFFooBar")]
        internal void LocalIdentifier_IsMatch(LocalIdentifierTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData(" ")]
        [InjectData("F")]
        [InjectData("")]
        [InjectData("FooBar")]
        [InjectData("3fooBar")]
        [InjectData("3fooBar")]
        [InjectData(" fooBar")]
        [InjectData("fooBar ")]
        [InjectData(" fooBar ")]
        [InjectData("foo_bar")]
        [InjectData("Foo/Bar")]
        internal void LocalIdentifier_IsNotMatch(LocalIdentifierTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData(">")]
        internal void GreaterThenOperator_IsMatch(GreaterThenOperatorTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData("> ")]
        [InjectData(" >")]
        [InjectData(">>")]
        [InjectData(">_")]
        internal void GreaterThenOperator_IsNotMatch(GreaterThenOperatorTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("<")]
        internal void LessThenOperator_IsMatch(LessThenOperatorTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData("< ")]
        [InjectData(" <")]
        [InjectData("<<")]
        [InjectData("<-")]
        internal void LessThenOperator_IsNotMatch(LessThenOperatorTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("<-")]
        internal void AssigmentOperator_IsMatch(AssigmentOperatorTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData("< ")]
        [InjectData(" <")]
        [InjectData("<- ")]
        [InjectData(" <-")]
        [InjectData("<-<")]
        [InjectData("<<")]
        internal void AssigmentOperator_IsNotMatch(AssigmentOperatorTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }
    }
}