using System;
using Evergreen.Domain.Grammar.Lexis.Directories;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Operators;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Whitespaces;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Identifiers;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Keywords;
using Photosphere.DependencyInjection.xUnit;
using Xunit;

namespace Evergreen.Domain.Grammar.Tests.Lexical.TokenTypes
{
    public class TokenTypesTests
    {
        [Theory]
        [InjectDependency(typeof(SpaceTokenType), " ")]
        [InjectDependency(typeof(IndentTokenType), "  ")]
        [InjectDependency(typeof(NewLineTokenType), "\n\r")]
        [InjectDependency(typeof(ModelKeywordTokenType), "model")]
        [InjectDependency(typeof(ServiceKeywordTokenType), "service")]
        [InjectDependency(typeof(InterfaceKeywordTokenType), "interface")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "F")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "FooBar")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "Foo2bar")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "Foo2Bar")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "FFFooBar")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "f")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "fooBar")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "foo2bar")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "foo2Bar")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "fFFooBar")]
        [InjectDependency(typeof(GreaterThenOperatorTokenType), ">")]
        [InjectDependency(typeof(LessThenOperatorTokenType), "<")]
        [InjectDependency(typeof(AssigmentOperatorTokenType), "<-")]
        internal void IsMatch(Type type, string value, ILexicalTokenTypesDirectory lexicalTokenTypesDirectory)
        {
            Assert.True(lexicalTokenTypesDirectory.Get(type).IsMatch(value));
        }

        [Theory]
        [InjectDependency(typeof(SpaceTokenType), "")]
        [InjectDependency(typeof(SpaceTokenType), "  ")]
        [InjectDependency(typeof(SpaceTokenType), " _")]
        [InjectDependency(typeof(SpaceTokenType), "d ")]
        [InjectDependency(typeof(SpaceTokenType), "ef")]
        [InjectDependency(typeof(IndentTokenType), "")]
        [InjectDependency(typeof(IndentTokenType), " ")]
        [InjectDependency(typeof(IndentTokenType), "   ")]
        [InjectDependency(typeof(IndentTokenType), "d  ")]
        [InjectDependency(typeof(IndentTokenType), "  d")]
        [InjectDependency(typeof(IndentTokenType), "ef")]
        [InjectDependency(typeof(NewLineTokenType), "")]
        [InjectDependency(typeof(NewLineTokenType), " ")]
        [InjectDependency(typeof(NewLineTokenType), "  ")]
        [InjectDependency(typeof(NewLineTokenType), "(")]
        [InjectDependency(typeof(NewLineTokenType), "\r\n")]
        [InjectDependency(typeof(NewLineTokenType), "\n\r ")]
        [InjectDependency(typeof(NewLineTokenType), " \n\r")]
        [InjectDependency(typeof(NewLineTokenType), " \n\r ")]
        [InjectDependency(typeof(NewLineTokenType), "wg2g2\n\r2g23g2")]
        [InjectDependency(typeof(ModelKeywordTokenType), "")]
        [InjectDependency(typeof(ModelKeywordTokenType), " ")]
        [InjectDependency(typeof(ModelKeywordTokenType), " model")]
        [InjectDependency(typeof(ModelKeywordTokenType), "model ")]
        [InjectDependency(typeof(ModelKeywordTokenType), "m")]
        [InjectDependency(typeof(ServiceKeywordTokenType), "")]
        [InjectDependency(typeof(ServiceKeywordTokenType), " ")]
        [InjectDependency(typeof(ServiceKeywordTokenType), " service")]
        [InjectDependency(typeof(ServiceKeywordTokenType), "service ")]
        [InjectDependency(typeof(ServiceKeywordTokenType), "s")]
        [InjectDependency(typeof(InterfaceKeywordTokenType), "")]
        [InjectDependency(typeof(InterfaceKeywordTokenType), " ")]
        [InjectDependency(typeof(InterfaceKeywordTokenType), " interface")]
        [InjectDependency(typeof(InterfaceKeywordTokenType), "interface ")]
        [InjectDependency(typeof(InterfaceKeywordTokenType), "i")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "")]
        [InjectDependency(typeof(TypeIdentifierTokenType), " ")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "f")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "fooBar")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "3fooBar")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "3FooBar")]
        [InjectDependency(typeof(TypeIdentifierTokenType), " FooBar")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "FooBar ")]
        [InjectDependency(typeof(TypeIdentifierTokenType), " FooBar ")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "Foo_Bar")]
        [InjectDependency(typeof(TypeIdentifierTokenType), "Foo/Bar")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "")]
        [InjectDependency(typeof(LocalIdentifierTokenType), " ")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "F")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "FooBar")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "3fooBar")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "3fooBar")]
        [InjectDependency(typeof(LocalIdentifierTokenType), " fooBar")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "fooBar ")]
        [InjectDependency(typeof(LocalIdentifierTokenType), " fooBar ")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "foo_bar")]
        [InjectDependency(typeof(LocalIdentifierTokenType), "Foo/Bar")]
        [InjectDependency(typeof(GreaterThenOperatorTokenType), "")]
        [InjectDependency(typeof(GreaterThenOperatorTokenType), "> ")]
        [InjectDependency(typeof(GreaterThenOperatorTokenType), " >")]
        [InjectDependency(typeof(GreaterThenOperatorTokenType), ">>")]
        [InjectDependency(typeof(GreaterThenOperatorTokenType), ">_")]
        [InjectDependency(typeof(LessThenOperatorTokenType), "")]
        [InjectDependency(typeof(LessThenOperatorTokenType), "< ")]
        [InjectDependency(typeof(LessThenOperatorTokenType), " <")]
        [InjectDependency(typeof(LessThenOperatorTokenType), "<<")]
        [InjectDependency(typeof(LessThenOperatorTokenType), "<-")]
        [InjectDependency(typeof(AssigmentOperatorTokenType), "")]
        [InjectDependency(typeof(AssigmentOperatorTokenType), "< ")]
        [InjectDependency(typeof(AssigmentOperatorTokenType), " <")]
        [InjectDependency(typeof(AssigmentOperatorTokenType), "<- ")]
        [InjectDependency(typeof(AssigmentOperatorTokenType), " <-")]
        [InjectDependency(typeof(AssigmentOperatorTokenType), "<-<")]
        [InjectDependency(typeof(AssigmentOperatorTokenType), "<<")]
        internal void IsNotMatch(Type type, string value, ILexicalTokenTypesDirectory lexicalTokenTypesDirectory)
        {
            Assert.False(lexicalTokenTypesDirectory.Get(type).IsMatch(value));
        }
    }
}