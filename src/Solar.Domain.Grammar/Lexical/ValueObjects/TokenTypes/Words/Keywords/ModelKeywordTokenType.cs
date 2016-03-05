﻿using Solar.Domain.Grammar.Lexical.Services;

namespace Solar.Domain.Grammar.Lexical.ValueObjects.TokenTypes.Words.Keywords
{
    public class ModelKeywordTokenType : KeywordTokenTypeBase
    {
        public ModelKeywordTokenType(IKeywordsDirectory keywordsDirectory)
            : base(keywordsDirectory) {}
    }
}