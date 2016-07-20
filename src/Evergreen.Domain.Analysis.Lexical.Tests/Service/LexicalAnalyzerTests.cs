using System.Collections.Generic;
using Evergreen.Domain.Analysis.Lexical.Exceptions;
using Evergreen.Domain.Analysis.Lexical.Services;
using Evergreen.Domain.Grammar.GlobalStateObjects;
using LightInject.xUnit2;
using Xunit;

namespace Evergreen.Domain.Analysis.Lexical.Tests.Service
{
    public class LexicalAnalyzerTests
    {
        [Theory]
        [InjectData("", 0)]
        [InjectData(" ", 1)]
        [InjectData("  ", 1)]
        [InjectData("   ", 2)]
        [InjectData("kjhHlJHlHlHLHlHRIdd2222", 1)]
        [InjectData("kjhHlJHlHlHLHlH RIdd2222", 3)]
        [InjectData("foo <- a() + b - c * d / e", 23)]
        [InjectData("foo <- bar()", 7)]
        [InjectData("foo <- a + b", 9)]
        [InjectData("model foo", 3)]
        [InjectData("model model service", 5)]
        internal void Analyze_ValidString_ValidTokentCounts(ILexicalAnalyzer analyzer, IReadOnlyList<ITokenType> tokenTypes, string testString, int expectedTokensCount)
        {
            var result = analyzer.Analyze(testString).Count;
            Assert.Equal(expectedTokensCount, result);
        }

        [Theory]
        [InjectData("_")]
        internal void Analyze_InvalidString_Exception(ILexicalAnalyzer analyzer, string testString)
        {
            try
            {
                analyzer.Analyze(testString);
                Assert.True(false);
            }
            catch (LexicalAnalyzerException)
            {
                Assert.True(true);
            }
        }

        [Theory]
        [InjectData("_")]
        internal void Analyze_InvalidString_HaveInnerException(ILexicalAnalyzer analyzer, string testString)
        {
            try
            {
                analyzer.Analyze(testString);
                Assert.True(false);
            }
            catch (LexicalAnalyzerException exception)
            {
                Assert.NotNull(exception.InnerException);
            }
        }
    }
}