package lexer

import "fmt"

func NewUnrecognizedLexemeError(line uint, position uint) UnrecognizedLexemeError {
	return UnrecognizedLexemeError{line, position}
}

type UnrecognizedLexemeError struct {
	line     uint
	position uint
}

func (e UnrecognizedLexemeError) Error() string {
	return fmt.Sprintf("Unrecognized lexeme at %d:%d", e.line, e.position)
}
