﻿using System.Text.RegularExpressions;
using Solar.Domain.Grammar.Lexis.Constants;

namespace Solar.Domain.Grammar.Lexis.ValueObjects.TokenTypes.Operators
{
    public class AssigmentOperatorTokenType : TokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.LeftArrow;
    }
}