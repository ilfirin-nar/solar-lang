using System.Collections.Generic;
using Solar.Domain.Analysis.Lexical.Entities;
using Solar.Domain.Analysis.Lexical.EntityFactories;
using Solar.Domain.Analysis.Lexical.EntityFactories.RawData;
using Solar.Domain.Analysis.Lexical.Exceptions;
using Solar.Domain.Grammar.Exceptions;
using Solar.Domain.Grammar.Lexical.Services;

namespace Solar.Domain.Analysis.Lexical
{
    internal class LexicalAnalyzer : ILexicalAnalyzer
    {
        private readonly ITokenFactory _tokenFactory;
        private readonly ITokenTypeRecognizer _tokenTypeRecognizer;

        public LexicalAnalyzer(ITokenFactory tokenFactory, ITokenTypeRecognizer tokenTypeRecognizer)
        {
            _tokenFactory = tokenFactory;
            _tokenTypeRecognizer = tokenTypeRecognizer;
        }

        public IReadOnlyList<Token> Analyse(string content)
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

        private IReadOnlyList<Token> Parse(string content)
        {
            var result = new List<Token>();
            if (content == string.Empty)
            {
                return result;
            }
            var tokenRawData = GetNewTokenRawData();
            foreach (var character in content)
            {
                if (tokenRawData.IsEmpty)
                {
                    AddCharacterToLexeme(tokenRawData, character);
                    continue;
                }
                var checkedLexeme = tokenRawData.Lexeme + character;
                if(!tokenRawData.TokenType.CharacteristicRegex.IsMatch(checkedLexeme))
                {
                    var clarifyedTokenType = _tokenTypeRecognizer.ClarifyTokenType(checkedLexeme, tokenRawData.TokenType);
                    if (clarifyedTokenType != tokenRawData.TokenType)
                    {
                        tokenRawData += character;
                        tokenRawData.TokenType = clarifyedTokenType;
                        continue;
                    }
                    var token = _tokenFactory.Produce(tokenRawData);
                    tokenRawData = GetNewTokenRawData();
                    AddCharacterToLexeme(tokenRawData, character);
                    result.Add(token);
                }
                else
                {
                    AddCharacterToLexeme(tokenRawData, character);
                }
            }
            result.Add(_tokenFactory.Produce(tokenRawData));
            return result;
        }

        private static TokenRawData GetNewTokenRawData()
        {
            return new TokenRawData(string.Empty);
        }

        private void AddCharacterToLexeme(TokenRawData tokenRawData, char character)
        {
            tokenRawData += character;
            tokenRawData.TokenType = _tokenTypeRecognizer.Recognize(tokenRawData.Lexeme);
        }
    }
}