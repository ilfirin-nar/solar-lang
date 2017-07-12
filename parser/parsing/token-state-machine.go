package parsing

import (
	"errors"
	"evergreen-lang/grammar"
	"evergreen-lang/lexer"
)

func NewTokenStateMachine(tokens []*lexer.Token) *TokenStateMachine {
	return &TokenStateMachine{tokens: tokens, currentIndex: -1}
}

type TokenStateMachine struct {
	tokens       []*lexer.Token
	currentIndex int
}

func (s *TokenStateMachine) GetCurrent() *lexer.Token {
	return s.tokens[s.currentIndex]
}

func (s *TokenStateMachine) GetNext() (*lexer.Token, error) {
	if s.currentIndex >= len(s.tokens)-1 {
		return nil, errors.New("End of stream")
	}
	s.currentIndex++
	return s.tokens[s.currentIndex], nil
}

func (s *TokenStateMachine) MoveNext() {
	if s.currentIndex <= len(s.tokens) {
		s.currentIndex++
	}
}

func (s *TokenStateMachine) PryNext() *lexer.Token {
	return s.tokens[s.currentIndex+1]
}

func (s *TokenStateMachine) IsEnd() bool {
	return s.currentIndex >= len(s.tokens)-1
}

func (s *TokenStateMachine) CheckNextToken(lexemeType grammar.LexemeType) (*lexer.Token, bool) {
	token, err := s.GetNext()
	if err != nil {
		return nil, false
	}
	return token, token.LexemeType == lexemeType
}
