package lexer

import (
	"errors"
	"regexp"
)

const maxLexemeLength = 50

func Lex(source string) ([]*Lexeme, error) {
	if len(source) == 0 {
		return nil, errors.New("Empty source, nothing to lex")
	}

	var (
		lexemes    []*Lexeme
		lineNumber uint
	)
	for start := 0; start < len(source); start++ {
		for end := start; end < len(source); end++ {
			checkedSubstring := source[start : end+1]
			if len(checkedSubstring) >= maxLexemeLength {
				return nil, NewUnrecognizedLexemeError(uint(start), lineNumber)
			}

			lexeme, err := getLexeme(checkedSubstring, uint(start), lineNumber)
			if err != nil {
				continue
			}
			if end+1 < len(source) && getType(source[start:end+2]) != InvalidLexemeType {
				continue
			}

			if lexeme.LexemeType == NewLine {
				lineNumber++
			}
			lexemes = append(lexemes, lexeme)
			start = end
			break
		}
	}
	return lexemes, nil
}

func getLexeme(value string, positionInLine uint, lineNumber uint) (*Lexeme, error) {
	lexemeType := getType(value)
	if lexemeType == InvalidLexemeType {
		return nil, errors.New("Invalid lexeme type")
	}
	position := NewLexemePosition(positionInLine, lineNumber)
	return NewLexeme(value, lexemeType, position), nil
}

func getType(value string) LexemeType {
	if checkType(value, Space) {
		return Space
	}
	if checkType(value, NewLine) {
		return NewLine
	}
	if checkType(value, Variable) {
		return Variable
	}
	if checkType(value, Assignment) {
		return Assignment
	}
	if checkType(value, Equal) {
		return Equal
	}
	if checkType(value, lessThan) {
		return lessThan
	}
	if checkType(value, GreatThan) {
		return GreatThan
	}
	if checkType(value, LessThanOrEq) {
		return LessThanOrEq
	}
	if checkType(value, GreatThanOrEq) {
		return GreatThanOrEq
	}
	if checkType(value, Addition) {
		return Addition
	}
	if checkType(value, Subtraction) {
		return Subtraction
	}
	if checkType(value, Multiply) {
		return Multiply
	}
	if checkType(value, Division) {
		return Division
	}
	if checkType(value, Print) {
		return Print
	}
	return InvalidLexemeType
}

func checkType(value string, lexemeType LexemeType) bool {
	result, err := regexp.Match(string(lexemeType), []byte(value))
	if err != nil {
		return false
	}
	return result
}
