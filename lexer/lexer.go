package lexer

import (
	"errors"
	"evergreen-lang/grammar"
	"regexp"
)

const maxLexemeLength = 50

func Lex(source string) ([]*Token, error) {
	if len(source) == 0 {
		return nil, errors.New("Empty source, nothing to lex")
	}

	var (
		lexemes    []*Token
		lineNumber uint
	)
	for start := 0; start < len(source); start++ {
		for end := start; end < len(source); end++ {
			checkedSubstring := source[start : end+1]
			if len(checkedSubstring) >= maxLexemeLength {
				return nil, NewUnrecognizedLexemeError(uint(start), lineNumber)
			}

			lexeme, err := getToken(checkedSubstring, uint(start), lineNumber)
			if err != nil {
				continue
			}
			if end+1 < len(source) && getType(source[start:end+2]) != grammar.InvalidLexemeType {
				continue
			}

			if lexeme.LexemeType == grammar.NewLine {
				lineNumber++
			}
			lexemes = append(lexemes, lexeme)
			start = end
			break
		}
	}
	return lexemes, nil
}

func getToken(value string, positionInLine uint, lineNumber uint) (*Token, error) {
	lexemeType := getType(value)
	if lexemeType == grammar.InvalidLexemeType {
		return nil, errors.New("Invalid lexeme type")
	}
	position := NewTokenPosition(positionInLine, lineNumber)
	return NewToken(value, lexemeType, position), nil
}

func getType(value string) grammar.LexemeType {
	if checkType(value, grammar.Space) {
		return grammar.Space
	}
	if checkType(value, grammar.NewLine) {
		return grammar.NewLine
	}
	if checkType(value, grammar.NumericLiteral) {
		return grammar.NumericLiteral
	}
	if checkType(value, grammar.Assignment) {
		return grammar.Assignment
	}
	if checkType(value, grammar.Equality) {
		return grammar.Equality
	}
	if checkType(value, grammar.LessThan) {
		return grammar.LessThan
	}
	if checkType(value, grammar.GreatThan) {
		return grammar.GreatThan
	}
	if checkType(value, grammar.LessThanOrEq) {
		return grammar.LessThanOrEq
	}
	if checkType(value, grammar.GreatThanOrEq) {
		return grammar.GreatThanOrEq
	}
	if checkType(value, grammar.Addition) {
		return grammar.Addition
	}
	if checkType(value, grammar.Subtraction) {
		return grammar.Subtraction
	}
	if checkType(value, grammar.Multiplication) {
		return grammar.Multiplication
	}
	if checkType(value, grammar.Division) {
		return grammar.Division
	}
	if checkType(value, grammar.PrintKeyword) {
		return grammar.PrintKeyword
	}
	if checkType(value, grammar.Identifier) {
		return grammar.Identifier
	}
	return grammar.InvalidLexemeType
}

func checkType(value string, lexemeType grammar.LexemeType) bool {
	result, err := regexp.Match(string(lexemeType), []byte(value))
	if err != nil {
		return false
	}
	return result
}
