package lexer

func NewTokenPosition(line uint, position uint) *TokenPosition {
	return &TokenPosition{line, position}
}

type TokenPosition struct {
	line     uint
	position uint
}

func (t *TokenPosition) GetLine() uint {
	return t.line
}

func (t *TokenPosition) GetPosition() uint {
	return t.position
}
