package lexer

func NewLexeme(value string, lexemeType LexemeType, position *LexemePosition) *Lexeme {
	return &Lexeme{value, lexemeType, position}
}

type Lexeme struct {
	Value      string
	LexemeType LexemeType
	Position   *LexemePosition
}

func (l *Lexeme) GetValue() string {
	return l.Value
}

func (l *Lexeme) GetPosition() *LexemePosition {
	return l.Position
}
