﻿using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Lexemes;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Operators
{
    public class AdditionOperatorTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemeRegularExpressions.Addition;
    }
}