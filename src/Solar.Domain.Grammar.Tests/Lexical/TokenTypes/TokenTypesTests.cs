using System;
using LightInject.xUnit2;
using Solar.Domain.Grammar.Lexis.Directories;
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
        [InjectData(typeof(SpaceTokenType), " ")]
        [InjectData(typeof(IndentTokenType), "  ")]
        [InjectData(typeof(NewLineTokenType), "\n\r")]
        [InjectData(typeof(ModelKeywordTokenType), "model")]
        [InjectData(typeof(ServiceKeywordTokenType), "service")]
        [InjectData(typeof(TypeIdentifierTokenType), "F")]
        [InjectData(typeof(TypeIdentifierTokenType), "FooBar")]
        [InjectData(typeof(TypeIdentifierTokenType), "Foo2bar")]
        [InjectData(typeof(TypeIdentifierTokenType), "Foo2Bar")]
        [InjectData(typeof(TypeIdentifierTokenType), "FFFooBar")]
        [InjectData(typeof(LocalIdentifierTokenType), "f")]
        [InjectData(typeof(LocalIdentifierTokenType), "fooBar")]
        [InjectData(typeof(LocalIdentifierTokenType), "foo2bar")]
        [InjectData(typeof(LocalIdentifierTokenType), "foo2Bar")]
        [InjectData(typeof(LocalIdentifierTokenType), "fFFooBar")]
        [InjectData(typeof(GreaterThenOperatorTokenType), ">")]
        [InjectData(typeof(LessThenOperatorTokenType), "<")]
        [InjectData(typeof(AssigmentOperatorTokenType), "<-")]
        internal void IsMatch(ITokenTypesDirectory tokenTypesDirectory, Type type, string value)
        {
            Assert.True(tokenTypesDirectory.Get(type).IsMatch(value));
        }

        [Theory]
        [InjectData(typeof(SpaceTokenType), "")]
        [InjectData(typeof(SpaceTokenType), "  ")]
        [InjectData(typeof(SpaceTokenType), " _")]
        [InjectData(typeof(SpaceTokenType), "d ")]
        [InjectData(typeof(SpaceTokenType), "ef")]
        [InjectData(typeof(IndentTokenType), "")]
        [InjectData(typeof(IndentTokenType), " ")]
        [InjectData(typeof(IndentTokenType), "   ")]
        [InjectData(typeof(IndentTokenType), "d  ")]
        [InjectData(typeof(IndentTokenType), "  d")]
        [InjectData(typeof(IndentTokenType), "ef")]
        [InjectData(typeof(NewLineTokenType), "")]
        [InjectData(typeof(NewLineTokenType), " ")]
        [InjectData(typeof(NewLineTokenType), "  ")]
        [InjectData(typeof(NewLineTokenType), "(")]
        [InjectData(typeof(NewLineTokenType), "\r\n")]
        [InjectData(typeof(NewLineTokenType), "\n\r ")]
        [InjectData(typeof(NewLineTokenType), " \n\r")]
        [InjectData(typeof(NewLineTokenType), " \n\r ")]
        [InjectData(typeof(NewLineTokenType), "wg2g2\n\r2g23g2")]
        [InjectData(typeof(ModelKeywordTokenType), "")]
        [InjectData(typeof(ModelKeywordTokenType), " ")]
        [InjectData(typeof(ModelKeywordTokenType), " model")]
        [InjectData(typeof(ModelKeywordTokenType), "model ")]
        [InjectData(typeof(ModelKeywordTokenType), "m")]
        [InjectData(typeof(ServiceKeywordTokenType), "")]
        [InjectData(typeof(ServiceKeywordTokenType), " ")]
        [InjectData(typeof(ServiceKeywordTokenType), " service")]
        [InjectData(typeof(ServiceKeywordTokenType), "service ")]
        [InjectData(typeof(ServiceKeywordTokenType), "s")]
        [InjectData(typeof(TypeIdentifierTokenType), "")]
        [InjectData(typeof(TypeIdentifierTokenType), " ")]
        [InjectData(typeof(TypeIdentifierTokenType), "f")]
        [InjectData(typeof(TypeIdentifierTokenType), "")]
        [InjectData(typeof(TypeIdentifierTokenType), "fooBar")]
        [InjectData(typeof(TypeIdentifierTokenType), "3fooBar")]
        [InjectData(typeof(TypeIdentifierTokenType), "3FooBar")]
        [InjectData(typeof(TypeIdentifierTokenType), " FooBar")]
        [InjectData(typeof(TypeIdentifierTokenType), "FooBar ")]
        [InjectData(typeof(TypeIdentifierTokenType), " FooBar ")]
        [InjectData(typeof(TypeIdentifierTokenType), "Foo_Bar")]
        [InjectData(typeof(TypeIdentifierTokenType), "Foo/Bar")]
        [InjectData(typeof(LocalIdentifierTokenType), "")]
        [InjectData(typeof(LocalIdentifierTokenType), " ")]
        [InjectData(typeof(LocalIdentifierTokenType), "F")]
        [InjectData(typeof(LocalIdentifierTokenType), "")]
        [InjectData(typeof(LocalIdentifierTokenType), "FooBar")]
        [InjectData(typeof(LocalIdentifierTokenType), "3fooBar")]
        [InjectData(typeof(LocalIdentifierTokenType), "3fooBar")]
        [InjectData(typeof(LocalIdentifierTokenType), " fooBar")]
        [InjectData(typeof(LocalIdentifierTokenType), "fooBar ")]
        [InjectData(typeof(LocalIdentifierTokenType), " fooBar ")]
        [InjectData(typeof(LocalIdentifierTokenType), "foo_bar")]
        [InjectData(typeof(LocalIdentifierTokenType), "Foo/Bar")]
        [InjectData(typeof(GreaterThenOperatorTokenType), "")]
        [InjectData(typeof(GreaterThenOperatorTokenType), "> ")]
        [InjectData(typeof(GreaterThenOperatorTokenType), " >")]
        [InjectData(typeof(GreaterThenOperatorTokenType), ">>")]
        [InjectData(typeof(GreaterThenOperatorTokenType), ">_")]
        [InjectData(typeof(LessThenOperatorTokenType), "")]
        [InjectData(typeof(LessThenOperatorTokenType), "< ")]
        [InjectData(typeof(LessThenOperatorTokenType), " <")]
        [InjectData(typeof(LessThenOperatorTokenType), "<<")]
        [InjectData(typeof(LessThenOperatorTokenType), "<-")]
        [InjectData(typeof(AssigmentOperatorTokenType), "")]
        [InjectData(typeof(AssigmentOperatorTokenType), "< ")]
        [InjectData(typeof(AssigmentOperatorTokenType), " <")]
        [InjectData(typeof(AssigmentOperatorTokenType), "<- ")]
        [InjectData(typeof(AssigmentOperatorTokenType), " <-")]
        [InjectData(typeof(AssigmentOperatorTokenType), "<-<")]
        [InjectData(typeof(AssigmentOperatorTokenType), "<<")]
        internal void IsNotMatch(ITokenTypesDirectory tokenTypesDirectory, Type type, string value)
        {
            Assert.False(tokenTypesDirectory.Get(type).IsMatch(value));
        }
    }
}