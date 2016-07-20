﻿using System.Text.RegularExpressions;
using Evergreen.Domain.Grammar.Lexis.Static;

namespace Evergreen.Domain.Grammar.Lexis.GlobalStateObjects.TokenTypes.Operators
{
    public class AdditionOperatorTokenType : OperatorTokenTypeBase
    {
        protected override Regex CharacteristicRegex => LexemesRegularExpressions.Addition;
    }
}