﻿using System;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Brackets;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Operators;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Whitespaces;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Identifiers;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Keywords;
using Evergreen.Domain.Grammar.Lexis.Services;
using Evergreen.Domain.Grammar.Lexis.Services.Exceptions;
using LightInject.xUnit2;
using Xunit;

namespace Evergreen.Domain.Grammar.Tests.Lexical.Services
{
    public class TokenTypeRecognizerTests
    {
        [Theory]
        [InjectData("")]
        internal void Recognize_InvalidLexeme_Exception(ILexicalTokenTypeRecognizer recognizer, string lexeme)
        {
            try
            {
                recognizer.Recognize(lexeme);
                Assert.True(false);
            }
            catch (UnrecognizedTokenException)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InjectData(" ", typeof (SpaceTokenType))]
        [InjectData("  ", typeof(IndentTokenType))]
        [InjectData("\n\r", typeof(NewLineTokenType))]
        [InjectData("(", typeof(LeftParenthesisTokenType))]
        [InjectData(")", typeof(RightParenthesisTokenType))]
        [InjectData("<", typeof(LessThenOperatorTokenType))]
        [InjectData(">", typeof(GreaterThenOperatorTokenType))]
        [InjectData("<-", typeof(AssigmentOperatorTokenType))]
        [InjectData("+", typeof(AdditionOperatorTokenType))]
        [InjectData("-", typeof(SubstractionOperatorTokenType))]
        [InjectData("*", typeof(MultiplyOperatorTokenType))]
        [InjectData("/", typeof(DivisionOperatorTokenType))]
        [InjectData("fooBar", typeof(LocalIdentifierTokenType))]
        [InjectData("FooBar", typeof(TypeIdentifierTokenType))]
        [InjectData("model", typeof(ModelKeywordTokenType))]
        [InjectData("service", typeof(ServiceKeywordTokenType))]
        internal void Recognize_ValidLexeme_ValidTokenType(ILexicalTokenTypeRecognizer recognizer, string lexeme, Type tokenTypeType)
        {
            var result = recognizer.Recognize(lexeme);
            Assert.Equal(tokenTypeType, result.GetType());
        }
    }
}