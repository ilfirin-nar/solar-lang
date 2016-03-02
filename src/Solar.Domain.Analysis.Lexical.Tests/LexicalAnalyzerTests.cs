using System.Collections.Generic;
using LightInject.xUnit2;
using Xunit;

namespace Solar.Domain.Analysis.Lexical.Tests
{
    public class LexicalAnalyzerTests
    {
        [Theory, InjectData]
        internal void Analyse_ValidOneStatementString_ValidResult(ILexicalAnalyzer analyzer)
        {
            const string content = "foo <- bar()";
            var result = analyzer.Analyse(content);
            // TODO Finish this!
            Assert.True(true);
        }
    }
}