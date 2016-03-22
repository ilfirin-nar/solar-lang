using System.Collections.Generic;
using JetBrains.Annotations;
using Solar.Domain.Analysis.Lexical.Exceptions;
using Solar.Domain.Analysis.Lexical.Services.Parsing;
using Solar.Domain.Grammar.Entities;
using Solar.Domain.Grammar.EntityFactories;
using Solar.Domain.Grammar.EntityFactories.RawData;
using Solar.Domain.Grammar.Exceptions;
using Solar.Domain.Grammar.Lexis.Services;
using Solar.Infrastructure.Common.Extensions;

namespace Solar.Domain.Analysis.Lexical.Services
{
    internal class LexicalAnalyzer : ILexicalAnalyzer
    {
        private readonly ITokenFactory _tokenFactory;
        private readonly ITokenTypeRecognizer _tokenTypeRecognizer;
        private readonly ITokenTypeClarifier _tokenTypeClarifier;

        public LexicalAnalyzer(
            ITokenFactory tokenFactory, 
            ITokenTypeRecognizer tokenTypeRecognizer,
            ITokenTypeClarifier tokenTypeClarifier)
        {
            _tokenFactory = tokenFactory;
            _tokenTypeRecognizer = tokenTypeRecognizer;
            _tokenTypeClarifier = tokenTypeClarifier;
        }

        [NotNull]
        public IReadOnlyList<IToken> Analyze([NotNull] string content)
        {
            try
            {
                return Parse(content);
            }
            catch (GrammarException exception)
            {
                throw new LexicalAnalyzerException(exception);
            }
        }

        private IReadOnlyList<IToken> Parse(string content)
        {
            var result = new List<Token>();
            if (content.IsEmpty())
            {
                return result;
            }
            var tokenRawData = GetNewTokenRawData();
            foreach (var character in content)
            {
                tokenRawData = SetCharToLexeme(tokenRawData, character, result);
            }
            AddToResult(result, tokenRawData);
            return result;
        }

        private TokenRawData SetCharToLexeme(TokenRawData tokenRawData, char character, ICollection<Token> result)
        {
            if (tokenRawData.IsEmpty)
            {
                SetCharToToken(tokenRawData, character);
                return tokenRawData;
            }
            var checkedLexeme = tokenRawData.Lexeme + character;
            if (_tokenTypeRecognizer.IsMatch(checkedLexeme, tokenRawData.TokenType))
            {
                tokenRawData.Lexeme = checkedLexeme;
            }
            else
            {
                if (_tokenTypeClarifier.TryToClarifyTokenType(checkedLexeme, tokenRawData))
                {
                    AddCharToLexeme(tokenRawData, character);
                    return tokenRawData;
                }
                AddToResult(result, tokenRawData);
                tokenRawData = GetNewTokenRawData(character);
            }
            return tokenRawData;
        }

        private TokenRawData GetNewTokenRawData(char? character = null)
        {
            var tokenRawData = new TokenRawData(string.Empty);
            if (character == null)
            {
                return tokenRawData;
            }
            SetCharToToken(tokenRawData, character.Value);
            return tokenRawData;
        }

        private void SetCharToToken(TokenRawData tokenRawData, char character)
        {
            AddCharToLexeme(tokenRawData, character);
            tokenRawData.TokenType = _tokenTypeRecognizer.Recognize(tokenRawData.Lexeme);
        }

        private static void AddCharToLexeme(TokenRawData tokenRawData, char character)
        {
            tokenRawData.Lexeme += character;
        }

        private void AddToResult(ICollection<Token> result, TokenRawData tokenRawData)
        {
            result.Add(_tokenFactory.Produce(tokenRawData));
        }
    }
}