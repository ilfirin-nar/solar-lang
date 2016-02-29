using System;
using System.Collections.Generic;
using System.Linq;
using Solar.Domain.Analysis.LexicalAnalysis.Entities;
using Solar.Domain.Analysis.LexicalAnalysis.EntityFactories;
using Solar.Domain.Analysis.LexicalAnalysis.EntityFactories.RawData;
using Solar.Domain.Grammar.Lexical.Services;
using Solar.Domain.Grammar.Lexical.TokenTypes;

namespace Solar.Domain.Analysis.LexicalAnalysis
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

        public IList<Token> Analyse(string content)
        {
            return Parse(content).ToList();
        }

        private IEnumerable<Token> Parse(string content)
        {
            var tokenRawData = GetNewTokenRawData();
            foreach (var character in content)
            {
                if (IsNewToken(tokenRawData))
                {
                    AddCharacterToLexeme(tokenRawData, character);
                    continue;
                }
                if (IsNextTokenStarts(tokenRawData, character))
                {
                    var token = _tokenFactory.Produce(tokenRawData);
                    tokenRawData = GetNewTokenRawData();
                    yield return token;
                }
                else
                {
                    AddCharacterToLexeme(tokenRawData, character);
                }
            }
        }

        private static TokenRawData GetNewTokenRawData()
        {
            return new TokenRawData(string.Empty, new UndefinedToken());
        }

        private static bool IsNewToken(TokenRawData tokenRawData)
        {
            return tokenRawData.Lexeme == string.Empty;
        }

        private void AddCharacterToLexeme(TokenRawData token, char character)
        {
            token.Lexeme += character;
            token.TokenType = _tokenTypeRecognizer.Recognize(token.Lexeme);
        }

        private bool IsNextTokenStarts(TokenRawData tokenRawData, char character)
        {
            var checkedLexeme = tokenRawData.Lexeme + character;
            return _tokenTypeRecognizer.CheckTokenType(checkedLexeme, tokenRawData.TokenType);
        }
    }
}