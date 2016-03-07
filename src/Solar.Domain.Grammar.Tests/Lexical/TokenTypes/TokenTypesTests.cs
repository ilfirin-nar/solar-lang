using LightInject.xUnit2;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Operators;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Whitespaces;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Words.Identifiers;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Words.Keywords;
using Xunit;

namespace Solar.Domain.Grammar.Tests.Lexical.TokenTypes
{
    public class TokenTypesTests
    {
        [Theory]
        [InjectData(" ")]
        internal void SpaceTokenType_IsMatch(SpaceTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData("  ")]
        [InjectData(" _")]
        [InjectData("d ")]
        [InjectData("ef")]
        internal void SpaceTokenType_IsNotMatch(SpaceTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("  ")]
        internal void IndentTokenType_IsMatch(IndentTokenType tokenType, string value)
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
        internal void IndentTokenType_IsNotMatch(IndentTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("\n\r")]
        internal void NewLineTokenType_IsMatch(NewLineTokenType tokenType, string value)
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
        internal void NewLineTokenType_IsNotMatch(NewLineTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("model")]
        internal void ModelKeywordTokenType_IsMatch(ModelKeywordTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData(" ")]
        [InjectData(" model")]
        [InjectData("model ")]
        [InjectData("m")]
        internal void ModelKeywordTokenType_IsNotMatch(ModelKeywordTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("service")]
        internal void ServiceKeywordTokenType_IsMatch(ServiceKeywordTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData(" ")]
        [InjectData(" service")]
        [InjectData("service ")]
        [InjectData("s")]
        internal void ServiceKeywordTokenType_IsNotMatch(ServiceKeywordTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("F")]
        [InjectData("FooBar")]
        [InjectData("Foo2bar")]
        [InjectData("Foo2Bar")]
        [InjectData("FFFooBar")]
        internal void TypeIdentifierTokenType_IsMatch(TypeIdentifierTokenType tokenType, string value)
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
        internal void TypeIdentifierTokenType_IsNotMatch(TypeIdentifierTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("f")]
        [InjectData("fooBar")]
        [InjectData("foo2bar")]
        [InjectData("foo2Bar")]
        [InjectData("fFFooBar")]
        internal void LocalIdentifierTokenType_IsMatch(LocalIdentifierTokenType tokenType, string value)
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
        internal void LocalIdentifierTokenType_IsNotMatch(LocalIdentifierTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData(">")]
        internal void GreaterThenOperatorTokenType_IsMatch(GreaterThenOperatorTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData("> ")]
        [InjectData(" >")]
        [InjectData(">>")]
        [InjectData(">_")]
        internal void GreaterThenOperatorTokenType_IsNotMatch(GreaterThenOperatorTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("<")]
        internal void LessThenOperatorTokenType_IsMatch(LessThenOperatorTokenType tokenType, string value)
        {
            Assert.True(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("")]
        [InjectData("< ")]
        [InjectData(" <")]
        [InjectData("<<")]
        [InjectData("<-")]
        internal void LessThenOperatorTokenType_IsNotMatch(LessThenOperatorTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }

        [Theory]
        [InjectData("<-")]
        internal void AssigmentOperatorTokenType_IsMatch(AssigmentOperatorTokenType tokenType, string value)
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
        internal void AssigmentOperatorTokenType_IsNotMatch(AssigmentOperatorTokenType tokenType, string value)
        {
            Assert.False(tokenType.IsMatch(value));
        }
    }
}