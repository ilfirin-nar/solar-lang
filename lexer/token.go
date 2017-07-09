package lexer

import "evergreen-lang/grammar"

func NewToken(value string, lexemeType grammar.LexemeType, position *TokenPosition) *Token {
	return &Token{value, lexemeType, position}
}

type Token struct {
	Value      string
	LexemeType grammar.LexemeType
	Position   *TokenPosition
}

func (t *Token) GetValue() string {
	return t.Value
}

func (t *Token) GetPosition() *TokenPosition {
	return t.Position
}
