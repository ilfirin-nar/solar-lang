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
	if s.currentIndex >= len(s.tokens)-1 {
		return nil, errors.New("End of stream")
	}
	s.currentIndex++
	return s.tokens[s.currentIndex], nil
}

func (s *TokenStream) MoveNext() {
	if s.currentIndex <= len(s.tokens) {
		s.currentIndex++
	}
}

func (s *TokenStream) PryNext() *Token {
	return s.tokens[s.currentIndex+1]
}

func (s *TokenStream) IsEnd() bool {
	return s.currentIndex >= len(s.tokens)-1
}
