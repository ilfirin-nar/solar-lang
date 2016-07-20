﻿using System;
using Evergreen.Domain.Grammar.Lexis.Directories;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Operators;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Whitespaces;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Identifiers;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Keywords;
using LightInject.xUnit2;
using Xunit;

namespace Evergreen.Domain.Grammar.Tests.Lexical.TokenTypes
{
    public class TokenTypesTests
    {
        [Theory]
        [InjectData(typeof(SpaceTokenType), " ")]
        [InjectData(typeof(IndentTokenType), "  ")]
        [InjectData(typeof(NewLineTokenType), "\n\r")]
        [InjectData(typeof(ModelKeywordTokenType), "model")]
        [InjectData(typeof(ServiceKeywordTokenType), "service")]
        [InjectData(typeof(InterfaceKeywordTokenType), "interface")]
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
        internal void IsMatch(ILexicalTokenTypesDirectory lexicalTokenTypesDirectory, Type type, string value)
        {
            Assert.True(lexicalTokenTypesDirectory.Get(type).IsMatch(value));
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
        [InjectData(typeof(InterfaceKeywordTokenType), "")]
        [InjectData(typeof(InterfaceKeywordTokenType), " ")]
        [InjectData(typeof(InterfaceKeywordTokenType), " interface")]
        [InjectData(typeof(InterfaceKeywordTokenType), "interface ")]
        [InjectData(typeof(InterfaceKeywordTokenType), "i")]
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
        internal void IsNotMatch(ILexicalTokenTypesDirectory lexicalTokenTypesDirectory, Type type, string value)
        {
            Assert.False(lexicalTokenTypesDirectory.Get(type).IsMatch(value));
        }
    }
}