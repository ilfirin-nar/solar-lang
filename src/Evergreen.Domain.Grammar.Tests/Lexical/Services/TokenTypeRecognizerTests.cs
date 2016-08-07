using System;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Brackets;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Operators;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Whitespaces;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Identifiers;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Words.Keywords;
using Evergreen.Domain.Grammar.Lexis.Services;
using Evergreen.Domain.Grammar.Lexis.Services.Exceptions;
using Photosphere.DependencyInjection.xUnit;
using Xunit;

namespace Evergreen.Domain.Grammar.Tests.Lexical.Services
{
    public class TokenTypeRecognizerTests
    {
        [Theory]
        [InjectDependency("")]
        internal void Recognize_InvalidLexeme_Exception(string lexeme, ILexicalTokenTypeRecognizer recognizer)
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
        [InjectDependency(" ", typeof (SpaceTokenType))]
        [InjectDependency("  ", typeof(IndentTokenType))]
        [InjectDependency("\n\r", typeof(NewLineTokenType))]
        [InjectDependency("(", typeof(LeftParenthesisTokenType))]
        [InjectDependency(")", typeof(RightParenthesisTokenType))]
        [InjectDependency("<", typeof(LessThenOperatorTokenType))]
        [InjectDependency(">", typeof(GreaterThenOperatorTokenType))]
        [InjectDependency("<-", typeof(AssigmentOperatorTokenType))]
        [InjectDependency("+", typeof(AdditionOperatorTokenType))]
        [InjectDependency("-", typeof(SubstractionOperatorTokenType))]
        [InjectDependency("*", typeof(MultiplyOperatorTokenType))]
        [InjectDependency("/", typeof(DivisionOperatorTokenType))]
        [InjectDependency("fooBar", typeof(LocalIdentifierTokenType))]
        [InjectDependency("FooBar", typeof(TypeIdentifierTokenType))]
        [InjectDependency("model", typeof(ModelKeywordTokenType))]
        [InjectDependency("service", typeof(ServiceKeywordTokenType))]
        internal void Recognize_ValidLexeme_ValidTokenType(string lexeme, Type tokenTypeType, ILexicalTokenTypeRecognizer recognizer)
        {
            var result = recognizer.Recognize(lexeme);
            Assert.Equal(tokenTypeType, result.GetType());
        }
    }
}