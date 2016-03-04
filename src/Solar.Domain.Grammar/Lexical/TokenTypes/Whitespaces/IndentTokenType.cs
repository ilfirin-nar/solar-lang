﻿using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Lexemes;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Whitespaces
{
    public class IndentTokenType : ITokenType
    {
        public Regex CharacteristicRegex => LexemesRegularExpressions.Indent;
    }
}