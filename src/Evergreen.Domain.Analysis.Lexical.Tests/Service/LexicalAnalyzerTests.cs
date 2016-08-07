using System.Collections.Generic;
using Evergreen.Domain.Analysis.Lexical.Exceptions;
using Evergreen.Domain.Analysis.Lexical.Services;
using Evergreen.Domain.Grammar.GlobalStateObjects;
using Photosphere.DependencyInjection.xUnit;
using Xunit;

namespace Evergreen.Domain.Analysis.Lexical.Tests.Service
{
    public class LexicalAnalyzerTests
    {
        [Theory]
        [InjectDependency("", 0)]
        [InjectDependency(" ", 1)]
        [InjectDependency("  ", 1)]
        [InjectDependency("   ", 2)]
        [InjectDependency("kjhHlJHlHlHLHlHRIdd2222", 1)]
        [InjectDependency("kjhHlJHlHlHLHlH RIdd2222", 3)]
        [InjectDependency("foo <- a() + b - c * d / e", 23)]
        [InjectDependency("foo <- bar()", 7)]
        [InjectDependency("foo <- a + b", 9)]
        [InjectDependency("model foo", 3)]
        [InjectDependency("model model service", 5)]
        internal void Analyze_ValidString_ValidTokentCounts(string testString, int expectedTokensCount, ILexicalAnalyzer analyzer, IReadOnlyCollection<ITokenType> tokenTypes)
        {
            var result = analyzer.Analyze(testString).Count;
            Assert.Equal(expectedTokensCount, result);
        }

        [Theory]
        [InjectDependency("_")]
        internal void Analyze_InvalidString_Exception(string testString, ILexicalAnalyzer analyzer)
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
        [InjectDependency("_")]
        internal void Analyze_InvalidString_HaveInnerException(string testString, ILexicalAnalyzer analyzer)
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