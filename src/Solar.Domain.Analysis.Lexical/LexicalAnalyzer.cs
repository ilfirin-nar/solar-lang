using System.Collections.Generic;
using Solar.Domain.Analysis.Lexical.Entities;
using Solar.Domain.Analysis.Lexical.EntityFactories;
using Solar.Domain.Analysis.Lexical.EntityFactories.RawData;
using Solar.Domain.Analysis.Lexical.Exceptions;
using Solar.Domain.Grammar.Exceptions;
using Solar.Domain.Grammar.Lexical.Services;
using Solar.Domain.Grammar.Lexical.TokenTypes;

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
                    SetCharToToken(tokenRawData, character);
                    continue;
                }
                var checkedLexeme = tokenRawData.Lexeme + character;
                if(tokenRawData.TokenType.CharacteristicRegex.IsMatch(checkedLexeme))
                {
                    tokenRawData.Lexeme = checkedLexeme;
                }
                else
                {
                    if (TryToClarifyTokenType(checkedLexeme, tokenRawData, character))
                    {
                        continue;
                    }
                    AddToResult(result, tokenRawData);
                    tokenRawData = GetNewTokenRawData(character);
                }
            }
            result.Add(_tokenFactory.Produce(tokenRawData));
            return result;
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
            AddCharacterToLexeme(tokenRawData, character);
            RecognizeTokenType(tokenRawData);
        }

        private static void AddCharacterToLexeme(TokenRawData tokenRawData, char character)
        {
            tokenRawData.Lexeme += character;
        }

        private void RecognizeTokenType(TokenRawData token)
        {
            token.TokenType = _tokenTypeRecognizer.Recognize(token.Lexeme);
        }

        private void AddToResult(ICollection<Token> result, TokenRawData tokenRawData)
        {
            result.Add(_tokenFactory.Produce(tokenRawData));
        }

        private bool TryToClarifyTokenType(string checkedLexeme, TokenRawData tokenRawData, char character)
        {
            var clarifyedTokenType = _tokenTypeRecognizer.ClarifyTokenType(checkedLexeme, tokenRawData.TokenType);
            if (clarifyedTokenType == tokenRawData.TokenType)
            {
                return false;
            }
            ApplyClarifyedTokenType(tokenRawData, character, clarifyedTokenType);
            return true;
        }

        private static void ApplyClarifyedTokenType(TokenRawData tokenRawData, char character, ITokenType clarifyedTokenType)
        {
            AddCharacterToLexeme(tokenRawData, character);
            tokenRawData.TokenType = clarifyedTokenType;
        }
    }
}