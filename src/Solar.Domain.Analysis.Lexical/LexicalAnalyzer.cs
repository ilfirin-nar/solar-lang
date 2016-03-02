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
            // TODO see to one char forward!!
            foreach (var character in content)
            {
                if (IsEmptyToken(tokenRawData))
                {
                    AddCharacterToLexeme(tokenRawData, character);
                    continue;
                }
                if (IsNextTokenStarts(tokenRawData, character))
                {
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

        private static bool IsEmptyToken(TokenRawData tokenRawData)
        {
            return tokenRawData.Lexeme == string.Empty;
        }

        private void AddCharacterToLexeme(TokenRawData token, char character)
        {
            token.Lexeme += character;
            token.TokenType = _tokenTypeRecognizer.Recognize(token.Lexeme);
        }

        private static bool IsNextTokenStarts(TokenRawData tokenRawData, char character)
        {
            var checkedLexeme = tokenRawData.Lexeme + character;
            return !tokenRawData.TokenType.CharacteristicRegex.IsMatch(checkedLexeme);
        }
    }
}