﻿using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexical.Constants;

namespace Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Operators
{
    public class AdditionOperatorTokenType : TokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.Addition;
    }
}