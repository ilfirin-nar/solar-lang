﻿using Evergreen.Domain.Grammar.EntityFactories;
using Evergreen.Domain.Grammar.EntityFactories.RawData;
using Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Whitespaces;
using LightInject.xUnit2;
using Xunit;

namespace Evergreen.Domain.Grammar.Tests.EntityFactories
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
            Assert.Equal(result.Value, Content);
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