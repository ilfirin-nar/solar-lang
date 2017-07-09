package lexer

import (
	"errors"
	"fmt"
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
			if end+1 < len(source) && checkType(source[start:end+2], lexeme.LexemeType) {
				continue
			}

			if lexeme.LexemeType == NewLine {
				lineNumber++
			}
			lexemes = append(lexemes, lexeme)
			start = end + 1
			break
		}
	}
	return lexemes, nil
}

func getLexeme(value string, positionInLine uint, lineNumber uint) (*Lexeme, error) {
	lexemeType, err := getType(value)
	if err != nil {
		return nil, err
	}
	position := NewLexemePosition(positionInLine, lineNumber)
	return NewLexeme(value, lexemeType, position), nil
}

func getType(value string) (LexemeType, error) {
	if checkType(value, Space) {
		return Space, nil
	}
	if checkType(value, NewLine) {
		return NewLine, nil
	}
	if checkType(value, Variable) {
		return Variable, nil
	}
	if checkType(value, Assignment) {
		return Assignment, nil
	}
	if checkType(value, Equal) {
		return Equal, nil
	}
	if checkType(value, lessThan) {
		return lessThan, nil
	}
	if checkType(value, GreatThan) {
		return GreatThan, nil
	}
	if checkType(value, LessThanOrEq) {
		return LessThanOrEq, nil
	}
	if checkType(value, GreatThanOrEq) {
		return GreatThanOrEq, nil
	}
	if checkType(value, Addition) {
		return Addition, nil
	}
	if checkType(value, Subtraction) {
		return Subtraction, nil
	}
	if checkType(value, Multiply) {
		return Multiply, nil
	}
	if checkType(value, Division) {
		return Division, nil
	}
	if checkType(value, Print) {
		return Print, nil
	}
	return InvalidLexemeType, fmt.Errorf("Not recognized lexeme")
}

func checkType(value string, lexemeType LexemeType) bool {
	result, err := regexp.Match(string(lexemeType), []byte(value))
	if err != nil {
		return false
	}
	return result
}
