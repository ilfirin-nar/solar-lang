using System;
using LightInject.xUnit2;
using Solar.Domain.Grammar.Lexis.Services;
using Solar.Domain.Grammar.Lexis.Services.Exceptions;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Brackets;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Operators;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Whitespaces;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Words.Identifiers;
using Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Words.Keywords;
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
        internal void Recognize_ValidLexeme_ValidTokenType(ITokenTypeRecognizer recognizer, string lexeme, Type tokenTypeType)
        {
            var result = recognizer.Recognize(lexeme);
            Assert.Equal(tokenTypeType, result.GetType());
        }
    }
}