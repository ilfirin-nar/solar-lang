using LightInject.xUnit2;
using Solar.Domain.Analysis.Lexical.EntityFactories;
using Solar.Domain.Analysis.Lexical.EntityFactories.RawData;
using Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Whitespaces;
using Xunit;

namespace Solar.Domain.Analysis.Lexical.Tests.EntityFactories
{
    public class TokenFactoryTests
    {
        private const string Content = "test";

        [Theory, InjectData]
        internal void Produce_NotNullResult(ITokenFactory tokenFactory)
        {
            var data = new TokenRawData(Content, new SpaceTokenType());
            var result = tokenFactory.Produce(data);
            Assert.NotNull(result);
        }

        [Theory, InjectData]
        internal void Produce_ValidContent_ValidLexem(ITokenFactory tokenFactory)
        {
            var data = new TokenRawData(Content, new SpaceTokenType());
            var result = tokenFactory.Produce(data);
            Assert.Equal(result.Lexeme.Value, Content);
        }

        [Theory, InjectData]
        internal void Produce_ValidType_ValidLexem(ITokenFactory tokenFactory)
        {
            var tokenType = new SpaceTokenType();
            var data = new TokenRawData(Content, tokenType);
            var result = tokenFactory.Produce(data);
            Assert.Equal(result.Type, tokenType);
        }
    }
}