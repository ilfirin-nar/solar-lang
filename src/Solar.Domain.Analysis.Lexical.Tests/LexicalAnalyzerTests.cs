using System.Collections.Generic;
using LightInject.xUnit2;
using Solar.Domain.Analysis.Lexical.Exceptions;
using Solar.Domain.Grammar.Lexical.TokenTypes;
using Xunit;

namespace Solar.Domain.Analysis.Lexical.Tests
{
    public class LexicalAnalyzerTests
    {
        [Theory]
        [InjectData("", 0)]
        [InjectData(" ", 1)]
        [InjectData("  ", 1)]
        [InjectData("   ", 2)]
        [InjectData("kjhHlJHlHlHLHlHRIdddddddd2222", 1)]
        [InjectData("kjhHlJHlHlHLHlH RIdddddddd2222", 3)]
        [InjectData("foo <- a() + b - c * d / e", 23)]
        [InjectData("foo <- bar()", 7)]
        [InjectData("foo <- a + b", 9)]
        internal void Analyse_ValidString_ValidTokentCounts(ILexicalAnalyzer analyzer, IReadOnlyList<ITokenType> tokenTypes, string testString, int expectedTokensCount)
        {
            var result = analyzer.Analyse(testString).Count;
            Assert.Equal(expectedTokensCount, result);
        }

        [Theory]
        [InjectData("_")]
        internal void Analyse_InvalidString_Exception(ILexicalAnalyzer analyzer, string testString)
        {
            try
            {
                analyzer.Analyse(testString);
                Assert.True(false);
            }
            catch (LexicalAnalyzerException)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InjectData("_")]
        internal void Analyse_InvalidString_HaveInnerException(ILexicalAnalyzer analyzer, string testString)
        {
            try
            {
                analyzer.Analyse(testString);
                Assert.True(false);
            }
            catch (LexicalAnalyzerException exception)
            {
                Assert.NotNull(exception.InnerException);
            }
        }
    }
}