package lexer

import "errors"

func NewTokenStream(tokens []*Token) *TokenStream {
	return &TokenStream{tokens: tokens, currentIndex: -1}
}

type TokenStream struct {
	tokens       []*Token
	currentIndex int
}

func (s *TokenStream) GetCurrent() *Token {
	return s.tokens[s.currentIndex]
}

func (s *TokenStream) GetNext() (*Token, error) {
	s.currentIndex++
	if s.currentIndex > len(s.tokens) {
		return nil, errors.New("End of stream")
	}
	return s.tokens[s.currentIndex], nil
}
