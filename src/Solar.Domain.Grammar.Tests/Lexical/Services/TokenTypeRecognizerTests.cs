﻿using System;
using LightInject.xUnit2;
using Solar.Domain.Grammar.Lexical.Services;
using Solar.Domain.Grammar.Lexical.Services.Exceptions;
using Solar.Domain.Grammar.Lexical.TokenTypes.Brackets;
using Solar.Domain.Grammar.Lexical.TokenTypes.Identifiers;
using Solar.Domain.Grammar.Lexical.TokenTypes.Operators;
using Solar.Domain.Grammar.Lexical.TokenTypes.Whitespaces;
using Xunit;

namespace Solar.Domain.Grammar.Tests.Lexical.Services
{
    public class TokenTypeRecognizerTests
    {
        [Theory]
        [InjectData("")]
        internal void Recognize_InvalidLexeme_Exception(ITokenTypeRecognizer recognizer, string lexeme)
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
        [InjectData("(", typeof(LeftParentheseTokenType))]
        [InjectData(")", typeof(RightParentheseTokenType))]
        [InjectData("fooBar", typeof(LocalIdentifierTokenType))]
        [InjectData("FooBar", typeof(TypeIdentifierTokenType))]
        [InjectData("<-", typeof(AssigmentOperatorTokenType))]
        [InjectData("+", typeof(AdditionOperatorTokenType))]
        [InjectData("-", typeof(SubstractionOperatorTokenType))]
        [InjectData("*", typeof(MultiplyOperatorTokenType))]
        [InjectData("/", typeof(DivisionOperatorTokenType))]
        internal void Recognize_ValidLexeme_ValidTokenType(ITokenTypeRecognizer recognizer, string lexeme, Type tokenTypeType)
        {
            var result = recognizer.Recognize(lexeme);
            Assert.Equal(tokenTypeType, result.GetType());
        }
    }
}