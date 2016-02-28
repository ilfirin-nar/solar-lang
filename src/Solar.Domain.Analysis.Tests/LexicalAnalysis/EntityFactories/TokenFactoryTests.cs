using LightInject.xUnit2;
using Solar.Domain.Analysis.LexicalAnalysis.EntityFactories;
using Solar.Domain.Analysis.LexicalAnalysis.EntityFactories.RawData;
using Solar.Domain.Grammar.Enums;
using Xunit;

namespace Solar.Domain.Analysis.Tests.LexicalAnalysis.EntityFactories
{
    public class TokenFactoryTests
    {
        private const string Content = "test";

        [Theory, InjectData]
        internal void Produce_NotNullResult(ITokenFactory tokenFactory)
        {
            var data = new TokenRawData(Content, TokenType.Expression);
            var result = tokenFactory.Produce(data);
            Assert.NotNull(result);
        }

        [Theory, InjectData]
        internal void Produce_ValidContent_ValidLexem(ITokenFactory tokenFactory)
        {
            var data = new TokenRawData(Content, TokenType.Expression);
            var result = tokenFactory.Produce(data);
            Assert.Equal(result.Lexem.Value, Content);
        }

        [Theory, InjectData]
        internal void Produce_ValidType_ValidLexem(ITokenFactory tokenFactory)
        {
            var data = new TokenRawData(Content, TokenType.Expression);
            var result = tokenFactory.Produce(data);
            Assert.Equal(result.Type, TokenType.Expression);
        }
    }
}