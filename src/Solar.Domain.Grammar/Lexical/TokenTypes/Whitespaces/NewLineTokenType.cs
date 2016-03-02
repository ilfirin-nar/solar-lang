﻿using System.Text.RegularExpressions;
using Solar.Domain.Text;

namespace Solar.Domain.Grammar.Lexical.TokenTypes.Whitespaces
{
    public class NewLineTokenType : ITokenType
    {
        public Regex CharacteristicRegex => RegularExpressions.NewLine;
    }
}