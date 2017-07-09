package lexer

func NewLexemePosition(line uint, position uint) *LexemePosition {
	return &LexemePosition{line, position}
}

type LexemePosition struct {
	line     uint
	position uint
}

func (l *LexemePosition) GetLine() uint {
	return l.line
}

func (l *LexemePosition) GetPosition() uint {
	return l.position
}
